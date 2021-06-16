using System;
using System.Collections.Generic;
using System.Linq;
using LiloDash.Domain.Interfaces.Model;
using LiloDash.Domain.Core.Models;
using LiloDash.Domain.Commands.Building;

namespace LiloDash.Domain.Model.EntityAudits
{
    /// <summary>
    /// Logged User
    /// </summary>
    public class EntityAuditUser: Entity
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}