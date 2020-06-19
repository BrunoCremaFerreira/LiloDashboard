using System;
using Domain.Validations.Building;
using Domain.Validations.Device;

namespace Domain.Commands.Device
{
    public class RegisterNewDeviceCommand : DeviceCommand
    {
        public RegisterNewDeviceCommand(string name, int hardwareAddress)
        {
            Name = name;
            HardwareAddress = hardwareAddress;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewDeviceCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}