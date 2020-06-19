using Domain.Commands.Device;

namespace Domain.Validations.Device
{
    public class RemoveDeviceCommandValidation : DeviceValidation<DeviceCommand>
    {
        public RemoveDeviceCommandValidation()
        {
            ValidateId();
        }
    }
}