using LiloDash.Domain.Commands.Room;

namespace LiloDash.Domain.Validations.Room
{
    public class RegisterNewRoomCommandValidation : RoomValidation<RegisterNewRoomCommand>
    {
        public RegisterNewRoomCommandValidation()
        {
            ValidateName();
        }
    }
}