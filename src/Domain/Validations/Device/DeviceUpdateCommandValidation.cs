using LiloDash.Domain.Commands.Device;

namespace LiloDash.Domain.Validations.Device
{
    public class DeviceUpdateCommandValidation : DeviceValidation<DeviceUpdateCommand>
    {
        public DeviceUpdateCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}