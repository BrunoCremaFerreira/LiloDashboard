using LiloDash.Domain.Commands.Device;

namespace LiloDash.Domain.Validations.Device
{
    public class RemoveDeviceCommandValidation : DeviceValidation<DeviceCommand>
    {
        public RemoveDeviceCommandValidation()
        {
            ValidateId();
        }
    }
}