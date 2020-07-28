using System;
using LiloDash.Domain.Core.Commands;

namespace LiloDash.Domain.Commands.Building
{
    public abstract class BuildingCommand: Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
    }
}