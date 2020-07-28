using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiloDash.Domain.Model;

namespace LiloDash.Infra.Data.EntityConfig
{
    public class DeviceConfig: IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id).
                HasColumnName("DeviceId").
                IsRequired();

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.HardwareAddress)
                .IsRequired();
        }
    }
}