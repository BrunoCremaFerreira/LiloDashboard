using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LiloDash.Application.ViewModels
{
    public class UserViewModel
    {
        [Key] 
        public Guid Id { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        [Required(ErrorMessage = "The Name is Required")]
        public string Name { get; set; }
        
        
        [EmailAddress]
        [DisplayName("E-mail")]
        [Required(ErrorMessage = "The E-mail is Required")]
        public string Email { get; set; }

        public string Password { get; set; }

        [DisplayName("Administrator")]
        public bool IsAdmin { get; set; }
    }
}
