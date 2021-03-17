using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LiloDash.Application.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
     
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
