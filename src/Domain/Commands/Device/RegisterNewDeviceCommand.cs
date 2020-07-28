using LiloDash.Domain.Validations.Device;

namespace LiloDash.Domain.Commands.Device
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