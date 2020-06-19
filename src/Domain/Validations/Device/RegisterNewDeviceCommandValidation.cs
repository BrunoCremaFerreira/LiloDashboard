using Domain.Commands.Device;

namespace Domain.Validations.Device
{
    public class RegisterNewDeviceCommandValidation : DeviceValidation<RegisterNewDeviceCommand>
    {
        public RegisterNewDeviceCommandValidation()
        {
            ValidateName();
        }
    }
}