using System;
using Domain.Core.Commands;

namespace Domain.Commands.Room
{
    public abstract class RoomCommand: Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
    }
}