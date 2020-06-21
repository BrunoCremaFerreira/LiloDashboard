using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Domain.Interfaces.Model;

namespace Application.ViewModels
{
    public class RoomViewModel : IPowerConsumption 
    {
        [Key]
        public Guid Id { get; set; }

        public Guid BuildingId { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        [Required(ErrorMessage = "The Room Name is Required")]
        public string Name { get; set; }

        public virtual IEnumerable<DeviceViewModel> Devices { get; set; }

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
