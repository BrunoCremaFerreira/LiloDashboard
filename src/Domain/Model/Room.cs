using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces.Model;
using Domain.Core.Models;

namespace Domain.Model
{
    /// <summary>
    /// Room of building
    /// </summary>
    public class Room: Entity<Guid>, IPowerConsumption
    {
        #region :: Constructors

        private Room()
        {
            Devices = new List<Device>();
        }
        
        public Room(Guid buildingId, Guid id, string name)
            :this()
        {
            BuildingId = BuildingId;
            Id = id;
            Name = name;
        }
        
        #endregion

        /// <summary>
        /// Friendly name of Room
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Building where the room is located
        /// </summary>
        public Guid BuildingId { get; private set; }

        /// <summary>
        /// Devices installed in the room
        /// </summary>
        public virtual IEnumerable<Device> Devices { get; }

        #region :: Measure Methods
        
        public float GetPower()
        {
            return Devices.Sum(e => e.GetPower());
        }

        public float AvarageConsumption()
        {
            return Devices.Sum(e => e.AvarageConsumption());
        }
        
        #endregion
    }
}