using System;
using Domain.Validations.Room;

namespace Domain.Commands.Room
{
    public class UpdateRoomCommand : RoomCommand
    {
        public UpdateRoomCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public override bool IsValid()
        {
            ValidationResult = new UpdateRoomCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}