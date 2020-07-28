using System;
using LiloDash.Domain.Core.Events;

namespace LiloDash.Domain.Events.User
{
    public class UserRegisteredEvent: Event
    {
        public UserRegisteredEvent(Guid id, string name, string email, bool isAdmin)
        {
            Id = id;
            Name = name;
            Email = email;
            IsAdmin = isAdmin;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public bool IsAdmin { get; private set; }
    }
}