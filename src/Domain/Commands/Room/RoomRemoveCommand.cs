using System;
using LiloDash.Domain.Validations.Room;

namespace LiloDash.Domain.Commands.Room
{
    public class RoomRemoveCommand : RoomCommand
    {
        public RoomRemoveCommand(Guid id)
            => Id = id;
        

        public override bool IsValid()
        {
            ValidationResult = new RoomRemoveCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}