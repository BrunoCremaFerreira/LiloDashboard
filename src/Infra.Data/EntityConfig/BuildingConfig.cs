using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiloDash.Domain.Model;

namespace LiloDash.Infra.Data.EntityConfig
{
    public class BuildingConfig : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id).
                HasColumnName("BuildingId").
                IsRequired();

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}