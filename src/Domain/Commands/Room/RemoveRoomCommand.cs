using System;
using Domain.Validations.Room;

namespace Domain.Commands.Room
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