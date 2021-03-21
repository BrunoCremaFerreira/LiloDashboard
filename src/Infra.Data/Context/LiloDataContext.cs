using System.IO;
using LiloDash.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LiloDash.Domain.Model;
using LiloDash.Domain.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace LiloDash.Infra.Data.Context
{
    public class LiloDataContext: DbContext, IUnitOfWork
    {
        #region :: DbSets

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
            //Get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            //Define the database to use
            optionsBuilder.UseMySQL(config.GetConnectionString("DefaultConnection"));
        }

        public async Task<bool> Commit()
            => await SaveChangesAsync() > 0;
    }
}