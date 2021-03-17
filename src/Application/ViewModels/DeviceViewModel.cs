using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LiloDash.Domain.Interfaces.Model;

namespace LiloDash.Application.ViewModels
{
    public class DeviceViewModel: IPowerConsumption
    {
        public Guid Id { get; set; }
        
        public Guid RoomId { get; set; }

        public virtual RoomViewModel Room { get; set; }

        public string Name { get; set; }

        public int HardwareAddress { get; set; }

        #region :: Measure Methods
        
        public float GetPower()
        {
            throw new System.NotImplementedException();
        }

        public float AvarageConsumption()
        {
            throw new System.NotImplementedException();
        }
        
        #endregion
    }
}
