using System;
using LiloDash.Domain.Validations.Room;

namespace LiloDash.Domain.Commands.Room
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