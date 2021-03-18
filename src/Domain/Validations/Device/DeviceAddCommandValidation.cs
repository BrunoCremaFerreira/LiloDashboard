using LiloDash.Domain.Commands.Device;

namespace LiloDash.Domain.Validations.Device
{
    public class DeviceAddCommandValidation : DeviceValidation<DeviceAddCommand>
    {
        public DeviceAddCommandValidation()
        {
            ValidateName();
        }
    }
}