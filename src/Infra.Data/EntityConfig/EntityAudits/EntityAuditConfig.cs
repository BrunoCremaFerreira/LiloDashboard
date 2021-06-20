using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiloDash.Domain.Model;
using LiloDash.Domain.Model.EntityAudits;

namespace LiloDash.Infra.Data.EntityConfig.EntityAudits
{
    public class EntityAuditConfig: IEntityTypeConfiguration<EntityAudit>
    {
        public void Configure(EntityTypeBuilder<EntityAudit> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id).
                HasColumnName("EntityAuditId").
                IsRequired();

            builder.Ignore(e=> e.KeyValues);
            builder.Ignore(e=> e.OldValues);
            builder.Ignore(e=> e.NewValues);

            builder.Property(e=> e.EntityName)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(e=> e.TransactionId);

            builder.Property(e=> e.TransactionId)
                .HasMaxLength(64);

        }
    }
}