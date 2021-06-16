using System;
using System.Collections.Generic;
using System.Linq;
using LiloDash.Domain.Interfaces.Model;
using LiloDash.Domain.Core.Models;
using LiloDash.Domain.Commands.Building;

namespace LiloDash.Domain.Enums.EntityAudits
{
    /// <summary>
    /// Entity Audit Operation
    /// </summary>
    [Flags]
    public enum EntityAuditOperationType
    {
        Unknown = 0,
        Add = 1,
        Update = 2,
        Remove = 4
    }
}