using Domain.Commands.Device;

namespace Domain.Validations.Device
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