using System;
using LiloDash.Domain.Core.Commands;

namespace LiloDash.Domain.Commands.Device
{
    public abstract class DeviceCommand: Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public int HardwareAddress { get; protected set; }
    }
}