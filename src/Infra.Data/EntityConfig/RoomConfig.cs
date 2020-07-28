using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiloDash.Domain.Model;

namespace LiloDash.Infra.Data.EntityConfig
{
    public class RoomConfig: IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(e => e.Id).
                HasColumnName("RoomId").
                IsRequired();

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}