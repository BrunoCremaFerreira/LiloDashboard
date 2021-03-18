using LiloDash.Domain.Validations.Room;
namespace LiloDash.Domain.Commands.Room
{
    public class RoomAddCommand : RoomCommand
    {
        public RoomAddCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new RoomAddCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}