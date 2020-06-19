using Domain.Commands.Room;

namespace Domain.Validations.Room
{
    public class RemoveRoomCommandValidation : RoomValidation<RoomCommand>
    {
        public RemoveRoomCommandValidation()
        {
            ValidateId();
        }
    }
}