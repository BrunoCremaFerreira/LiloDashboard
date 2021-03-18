using System;
using LiloDash.Domain.Validations.Room;

namespace LiloDash.Domain.Commands.Room
{
    public class RoomUpdateCommand : RoomCommand
    {
        public RoomUpdateCommand(Guid id, string name)
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