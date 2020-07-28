using LiloDash.Domain.Commands.Room;

namespace LiloDash.Domain.Validations.Room
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