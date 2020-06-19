using System;
using Domain.Validations.Device;

namespace Domain.Commands.Device
{
    public class RemoveDeviceCommand: DeviceCommand
    {
        public RemoveDeviceCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveDeviceCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}