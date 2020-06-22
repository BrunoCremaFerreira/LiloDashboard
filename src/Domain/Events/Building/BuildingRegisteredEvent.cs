using System;
using Domain.Core.Events;

namespace Domain.Events.Building
{
    public class BuildingRegisteredEvent: Event
    {
        public BuildingRegisteredEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }
    }
}