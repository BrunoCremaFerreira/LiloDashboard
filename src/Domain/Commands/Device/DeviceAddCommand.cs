using LiloDash.Domain.Validations.Device;

namespace LiloDash.Domain.Commands.Device
{
    public class DeviceAddCommand : DeviceCommand
    {
        public DeviceAddCommand(string name, int hardwareAddress)
        {
            Name = name;
            HardwareAddress = hardwareAddress;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeviceAddCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}