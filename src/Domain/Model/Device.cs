using System;
using LiloDash.Domain.Interfaces.Model;
using LiloDash.Domain.Core.Models;

namespace LiloDash.Domain.Model
{
    /// <summary>
    /// Measure device
    /// </summary>
    public class Device: Entity<Guid>, IPowerConsumption
    {
        #region :: Constructors
        
        public Device(Guid roomId, Guid id, string name, int hardwareAddress)
        {
            Id = id;
            RoomId = roomId;
            Name = name;
            HardwareAddress = hardwareAddress;
        }
        
        #endregion

        /// <summary>
        /// Room Id where the device is located
        /// </summary>
        public Guid RoomId { get; private set; }

        /// <summary>
        /// Room Where the device is located
        /// </summary>
        public virtual Room Room { get; }

        /// <summary>
        /// Friendly Device name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Physical Hardware Address
        /// </summary>
        public int HardwareAddress { get; private set; }

        #region :: Measure Methods
        
        public float GetPower()
        {
            throw new NotImplementedException();
        }

        public float AvarageConsumption()
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}