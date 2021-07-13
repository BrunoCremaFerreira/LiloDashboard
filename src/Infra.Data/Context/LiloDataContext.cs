using System.IO;
using LiloDash.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LiloDash.Domain.Model;
using LiloDash.Domain.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using LiloDash.Domain.Model.EntityAudits;
using System.Collections.Generic;
using LiloDash.Infra.Data.Audit;
using System.Transactions;
using System;
using LiloDash.Infra.Data.EFExtensions;
using LiloDash.Domain.Interfaces.Repository.Data.Users;
using System.Threading;

namespace LiloDash.Infra.Data.Context
{
    public class LiloDataContext: DbContext, IUnitOfWork
    {
        private readonly IUserLoggedRepository _userLoggedRepository;

        #region :: Constructors

        public LiloDataContext() { }

        public LiloDataContext(IUserLoggedRepository userLoggedRepository, 
            DbContextOptions options) : base (options)
        {
            _userLoggedRepository = userLoggedRepository;
        }

        public LiloDataContext(IUserLoggedRepository userLoggedRepository)
            : this()
        {
            _userLoggedRepository = userLoggedRepository;
        }

        #endregion

        #region :: DbSets

        public DbSet<EntityAudit> EntityAudits { get; set; }
        public DbSet<EntityAudit> EntityAuditRelations { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Device> Devices { get; set; }

        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Entity Config
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(LiloDataContext).Assembly);

            var fks = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e=> e.GetForeignKeys());

            //Set delete behaviour
            foreach(var rel in fks)
                rel.DeleteBehavior = DeleteBehavior.ClientSetNull;
                        
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Sekip if configured
            if(optionsBuilder.IsConfigured)
                return;

            //Get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            //Define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        public async Task<bool> Commit()
            => await SaveChangesAsync() > 0;

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var auditEntries = OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await OnAfterSaveChanges(auditEntries);
            return result;
        }

        #region :: Before Save Changes

        private IEnumerable<AuditEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach(var entry in ChangeTracker.Entries().ToList())
            {
                if(entry.Entity is EntityAudit
                    || entry.State == EntityState.Detached
                    || entry.State == EntityState.Unchanged)
                    continue;

                if(_userLoggedRepository != null)
                {
                    var userEntry = new EntityAuditUser()
                    {
                        Id = _userLoggedRepository.GetUserId(),
                        Name = _userLoggedRepository.GetUserName(),
                        Email = _userLoggedRepository.GetUserEmail()
                    };

                    var auditEntry = new AuditEntry(entry)
                    {
                        EntityName = entry.Metadata.GetTableName(),
                        TransactionId = Transaction.Current?
                            .TransactionInformation?.LocalIdentifier
                            ?? Guid.NewGuid().ToString(),
                        User = userEntry,
                        Operation = entry.State.ToOperationType()
                    };

                    auditEntries.Add(auditEntry);

                    foreach(var property in entry.Properties.ToList())
                    {
                        var propertyName = property.Metadata.Name;

                        if(property.IsTemporary)
                        {
                            auditEntry.TemporaryProperties.Add(property);
                            continue;
                        }

                        if (property.Metadata.IsPrimaryKey())
                        {
                            auditEntry.SetKeyValues(propertyName, property.CurrentValue);
                            continue;
                        }

                        switch(entry.State)
                        {
                            case EntityState.Added:
                                auditEntry.SetNewValues(propertyName, property.CurrentValue);
                                break;

                            case EntityState.Deleted:
                                auditEntry.SetOldValues(propertyName, property.CurrentValue);
                                break;

                            case EntityState.Modified:
                                if(property.IsModified && !Nullable.Equals(property.OriginalValue, property.CurrentValue))
                                {
                                    auditEntry.SetOldValues(propertyName, property.OriginalValue);
                                    auditEntry.SetNewValues(propertyName, property.CurrentValue);
                                }
                                break;
                        }
                    }
                }

                foreach(var auditEntry in auditEntries.Where(e=> !e.HasTemporaryProperties))
                    EntityAudits.Add(auditEntry);
            }

            return auditEntries
                .Where(e=> e.HasTemporaryProperties).ToList();
        }

        #endregion

        #region :: After Save Changes

        private Task OnAfterSaveChanges(IEnumerable<AuditEntry> auditEntries)
        {
            if(!(auditEntries?.Any() ?? false))
                return Task.CompletedTask;

            foreach(var entry in auditEntries)
            {
                foreach (var prop in entry.TemporaryProperties)
                {
                    if(prop.Metadata.IsPrimaryKey())
                        entry.SetKeyValues(prop.Metadata.Name, prop.CurrentValue);
                    else
                        entry.SetNewValues(prop.Metadata.Name, prop.CurrentValue);
                }
                EntityAudits.Add(entry);
            }

            return SaveChangesAsync();
        }

        #endregion
        
    }
}