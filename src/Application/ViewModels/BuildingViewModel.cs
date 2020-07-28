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
        [Key]
        public Guid Id { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        [Required(ErrorMessage = "The Building Name is Required")]
        public string Name { get; set; }

        public virtual IEnumerable<RoomViewModel> Rooms { get; set; }

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