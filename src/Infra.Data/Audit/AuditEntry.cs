using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiloDash.Domain.Model.EntityAudits;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace LiloDash.Infra.Data.Audit
{
    internal class AuditEntry : EntityAudit
    {
        public AuditEntry(EntityEntry entry)
        : base() => Entry = entry;

        public EntityEntry Entry { get; }

        public ICollection<PropertyEntry> TemporaryProperties { get; } 
            = new List<PropertyEntry>();

        public bool HasTemporaryProperties  
            => TemporaryProperties.Any();
    }
}