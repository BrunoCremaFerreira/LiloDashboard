using LiloDash.Domain.Commands.Room;

namespace LiloDash.Domain.Validations.Room
{
    public class RoomRemoveCommandValidation : RoomValidation<RoomRemoveCommand>
    {
        public RoomRemoveCommandValidation()
        {
            ValidateId();
        }
    }
}