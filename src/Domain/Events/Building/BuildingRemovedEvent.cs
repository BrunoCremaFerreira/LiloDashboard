using System;
using LiloDash.Domain.Core.Events;

namespace LiloDash.Domain.Events.Building
{
    public class BuildingRemovedEvent: Event
    {
        public BuildingRemovedEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}