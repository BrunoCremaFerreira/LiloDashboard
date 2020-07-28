using System;
using LiloDash.Domain.Validations.Device;

namespace LiloDash.Domain.Commands.Device
{
    public class UpdateDeviceCommand : DeviceCommand
    {
        public UpdateDeviceCommand(Guid id, string name, int hardwareAddress)
        {
            Id = id;
            Name = name;
            HardwareAddress = hardwareAddress;
        }
        
        public override bool IsValid()
        {
            ValidationResult = new UpdateDeviceCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}