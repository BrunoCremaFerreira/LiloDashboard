using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LiloDash.Domain.Interfaces.Model;

namespace LiloDash.Application.ViewModels
{
    public class BuildingViewModel: IPowerConsumption 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<RoomViewModel> Rooms { get; set; }

        #region :: Measure Methods
        
        public float GetPower()
            => Rooms.Sum(e => e.GetPower());
        
        public float AvarageConsumption()
            => Rooms.Sum(e => e.AvarageConsumption());
        
        #endregion
    }
}