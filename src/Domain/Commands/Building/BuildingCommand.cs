using System;
using Domain.Core.Commands;

namespace Domain.Commands.Building
{
    public abstract class BuildingCommand: Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
    }
}