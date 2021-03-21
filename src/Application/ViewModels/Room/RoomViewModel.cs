using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LiloDash.Domain.Interfaces.Model;

namespace LiloDash.Application.ViewModels
{
    public class RoomViewModel : IPowerConsumption 
    {
        public Guid Id { get; set; }

        public Guid BuildingId { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<DeviceViewModel> Devices { get; set; }

        #region :: Measure Methods
        
        public float GetPower()
            => Devices.Sum(e => e.GetPower());
        
        public float AvarageConsumption()
            => Devices.Sum(e => e.AvarageConsumption());
        
        
        #endregion
    }
}
