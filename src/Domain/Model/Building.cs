using System;
using System.Collections.Generic;
using System.Linq;
using LiloDash.Domain.Interfaces.Model;
using LiloDash.Domain.Core.Models;
using LiloDash.Domain.Commands.Building;

namespace LiloDash.Domain.Model
{
    /// <summary>
    /// Building Entity representation
    /// </summary>
    public class Building: Entity<Guid>, IPowerConsumption
    {
        #region :: Constructors

        private Building()
            => Rooms = new List<Room>();
        
        public Building(Guid id, string name)
            :this()
        {
            Id = id;
            Name = name;
        }
        
        #endregion
        
        #region :: Properties

        /// <summary>
        /// Friendly name of the house
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Building rooms
        /// </summary>
        public virtual IEnumerable<Room> Rooms { get; private set; }

        #endregion

        #region :: Measure Methods
        
        public float GetPower()
            => Rooms.Sum(e => e.GetPower());

        public float AvarageConsumption()
            => Rooms.Sum(e => e.AvarageConsumption());
        
        #endregion
    }
}