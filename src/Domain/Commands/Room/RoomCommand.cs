using System;
using LiloDash.Domain.Core.Commands;

namespace LiloDash.Domain.Commands.Room
{
    public abstract class RoomCommand: Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
    }
}