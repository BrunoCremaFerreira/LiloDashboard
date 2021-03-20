using LiloDash.Domain.Commands.Room;

namespace LiloDash.Domain.Validations.Room
{
    public class RoomAddCommandValidation : RoomValidation<RoomAddCommand>
    {
        public RoomAddCommandValidation()
        {
            ValidateName();
        }
    }
}