using System;
using LiloDash.Domain.Core.Events;

namespace Domain.Events.User
{
    public class UserUpdatedEvent: Event
    {
        public UserUpdatedEvent(Guid id, string name, string email, bool isAdmin)
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