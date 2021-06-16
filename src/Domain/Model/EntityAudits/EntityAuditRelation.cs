using System;
using System.Collections.Generic;
using System.Linq;
using LiloDash.Domain.Interfaces.Model;
using LiloDash.Domain.Core.Models;
using LiloDash.Domain.Commands.Building;

namespace LiloDash.Domain.Model.EntityAudits
{
    /// <summary>
    /// Entity relation
    /// </summary>
    public class AuditEntityRelation
    {
        public int Id { get; set; }

        public string EntityName { get; set; }

        public string ChildEntityName { get; set; }
    }
}