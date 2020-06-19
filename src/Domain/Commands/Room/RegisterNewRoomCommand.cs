using System;
using Domain.Validations.Room;

namespace Domain.Commands.Room
{
    public class RegisterNewRoomCommand : RoomCommand
    {
        public RegisterNewRoomCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewRoomCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}