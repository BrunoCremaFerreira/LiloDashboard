using System;
using LiloDash.Domain.Validations.Room;

namespace LiloDash.Domain.Commands.Room
{
    public class RemoveRoomCommand : RoomCommand
    {
        public RemoveRoomCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveRoomCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}