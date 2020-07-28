using System;
using LiloDash.Domain.Core.Events;

namespace Domain.Events.User
{
    public class UserRemovedEvent: Event
    {
        public UserRemovedEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}