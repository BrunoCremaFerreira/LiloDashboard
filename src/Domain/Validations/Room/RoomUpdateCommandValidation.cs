using LiloDash.Domain.Commands.Room;

namespace LiloDash.Domain.Validations.Room
{
    public class RoomUpdateCommandValidation : RoomValidation<RoomUpdateCommand>
    {
        public RoomUpdateCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}