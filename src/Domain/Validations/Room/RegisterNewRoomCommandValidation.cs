using Domain.Commands.Room;

namespace Domain.Validations.Room
{
    public class RegisterNewRoomCommandValidation : RoomValidation<RegisterNewRoomCommand>
    {
        public RegisterNewRoomCommandValidation()
        {
            ValidateName();
        }
    }
}