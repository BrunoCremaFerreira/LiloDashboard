using LiloDash.Domain.Commands.Device;

namespace LiloDash.Domain.Validations.Device
{
    public class UpdateDeviceCommandValidation : DeviceValidation<UpdateDeviceCommand>
    {
        public UpdateDeviceCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}