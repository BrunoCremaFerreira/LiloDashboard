using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiloDash.Domain.Core.Events;

namespace Data.EntityConfig
{
    public class StoredEventConfig : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasField("CreationDate");

            builder.Property(c => c.MessageType)
                .HasField("Action")
                .HasMaxLength(100);
        }
    }
}