using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LiloDash.Domain.Model.EntityAudits;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using LiloDash.Domain.Enums.EntityAudits;

namespace LiloDash.Infra.Data.EFExtensions
{
    public static class EnumExtensions
    {
        public static EntityAuditOperationType ToOperationType(this EntityState entityState)
        {
            switch(entityState)
            {
                case EntityState.Added: return EntityAuditOperationType.Add;
                case EntityState.Modified: return EntityAuditOperationType.Update;
                case EntityState.Deleted: return EntityAuditOperationType.Remove;
                default: return EntityAuditOperationType.Unknown;
            }
        }
    }
}