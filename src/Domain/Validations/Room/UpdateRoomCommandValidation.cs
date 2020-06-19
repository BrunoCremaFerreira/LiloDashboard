using Domain.Commands.Room;

namespace Domain.Validations.Room
{
    public class UpdateRoomCommandValidation : RoomValidation<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}