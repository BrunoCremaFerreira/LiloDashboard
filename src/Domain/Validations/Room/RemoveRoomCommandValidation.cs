using LiloDash.Domain.Commands.Room;

namespace LiloDash.Domain.Validations.Room
{
    public class RemoveRoomCommandValidation : RoomValidation<RoomCommand>
    {
        public RemoveRoomCommandValidation()
        {
            ValidateId();
        }
    }
}