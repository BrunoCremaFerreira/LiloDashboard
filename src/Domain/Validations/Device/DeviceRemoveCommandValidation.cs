using LiloDash.Domain.Commands.Device;

namespace LiloDash.Domain.Validations.Device
{
    public class DeviceRemoveCommandValidation : DeviceValidation<DeviceRemoveCommand>
    {
        public DeviceRemoveCommandValidation()
        {
            ValidateId();
        }
    }
}