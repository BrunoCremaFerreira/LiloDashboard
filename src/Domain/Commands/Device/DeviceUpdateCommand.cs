using System;
using LiloDash.Domain.Validations.Device;

namespace LiloDash.Domain.Commands.Device
{
    public class DeviceUpdateCommand : DeviceCommand
    {
        public DeviceUpdateCommand(Guid id, string name, int hardwareAddress)
        {
            Id = id;
            Name = name;
            HardwareAddress = hardwareAddress;
        }
        
        public override bool IsValid()
        {
            ValidationResult = new DeviceUpdateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}