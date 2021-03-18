using LiloDash.Domain.Commands.Device;

namespace LiloDash.Domain.Validations.Device
{
    public class DeviceAddCommandValidation : DeviceValidation<RegisterNewDeviceCommand>
    {
        public DeviceAddCommandValidation()
        {
            ValidateName();
        }
    }
}