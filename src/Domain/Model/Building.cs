using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces.Model;
using Domain.Core.Models;
using Domain.Commands.Building;

namespace Domain.Model
{
    /// <summary>
    /// Building Entity representation
    /// </summary>
    public class Building: Entity<Guid>, IPowerConsumption
    {
        #region :: Constructors

        private Building()
        {
            Rooms = new List<Room>();
        }
        
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

        /// <summary>
        /// Internal method to update data of a attached object instance
        /// </summary>
        internal void UpdateData(UpdateBuildingCommand updateCommand)
        {
            Name = updateCommand.Name;
        }

        #region :: Measure Methods
        
        public float GetPower()
        {
            return Rooms.Sum(e => e.GetPower());
        }

        public float AvarageConsumption()
        {
            return Rooms.Sum(e => e.AvarageConsumption());
        }
        
        #endregion
    }
}