using System;
using Domain.Core.Commands;

namespace Domain.Commands.Device
{
    public abstract class DeviceCommand: Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public int HardwareAddress { get; protected set; }
    }
}