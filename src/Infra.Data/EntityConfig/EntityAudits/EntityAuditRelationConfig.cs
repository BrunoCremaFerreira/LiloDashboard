using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiloDash.Domain.Model;
using LiloDash.Domain.Model.EntityAudits;
using System.Collections.Generic;

namespace LiloDash.Infra.Data.EntityConfig.EntityAudits
{
    public class EntityAuditRelationConfig: IEntityTypeConfiguration<EntityAuditRelation>
    {
        public void Configure(EntityTypeBuilder<EntityAuditRelation> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id)
                .HasColumnName("EntityAuditRelationId")
                .IsRequired();

            builder.Property(e => e.EntityName)
                .HasMaxLength(255);

            builder.Property(e => e.ChildEntityName)
                .HasMaxLength(255);

            builder.HasData(Seed);
        }

        private static IEnumerable<EntityAuditRelation> Seed
        {
            get
            {
                yield return new EntityAuditRelation { Id = 1, EntityName = "Building" };
                yield return new EntityAuditRelation { Id = 2, EntityName = "Device" };
                yield return new EntityAuditRelation { Id = 3, EntityName = "Room" };
                yield return new EntityAuditRelation { Id = 4, EntityName = "User" };
            }
        }
    }
}