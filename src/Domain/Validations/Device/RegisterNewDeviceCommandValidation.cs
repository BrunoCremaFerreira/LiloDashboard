using LiloDash.Domain.Commands.Device;

namespace LiloDash.Domain.Validations.Device
{
    public class RegisterNewDeviceCommandValidation : DeviceValidation<RegisterNewDeviceCommand>
    {
        public RegisterNewDeviceCommandValidation()
        {
            ValidateName();
        }
    }
}