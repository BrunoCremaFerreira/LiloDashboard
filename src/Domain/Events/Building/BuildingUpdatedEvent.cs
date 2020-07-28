using System;
using LiloDash.Domain.Core.Events;

namespace Domain.Events.Building
{
    public class BuildingUpdatedEvent: Event
    {
        public BuildingUpdatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }
    }
}