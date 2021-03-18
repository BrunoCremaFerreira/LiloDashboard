using System;
using LiloDash.Domain.Validations.Device;

namespace LiloDash.Domain.Commands.Device
{
    public class DeviceRemoveCommand: DeviceCommand
    {
        public DeviceRemoveCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeviceRemoveCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}