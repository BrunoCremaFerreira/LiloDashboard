using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces.Model;

namespace Application.ViewModels
{
    public class DeviceViewModel: IPowerConsumption
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Room is Required")]
        public Guid RoomId { get; set; }

        public virtual RoomViewModel Room { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        [Required(ErrorMessage = "The Device Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Hardware Address is Required")]
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
