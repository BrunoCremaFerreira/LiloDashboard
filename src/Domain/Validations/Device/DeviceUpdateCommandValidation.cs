using LiloDash.Domain.Commands.Device;

namespace LiloDash.Domain.Validations.Device
{
    public class DeviceUpdateCommandValidation : DeviceValidation<UpdateDeviceCommand>
    {
        public DeviceUpdateCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}