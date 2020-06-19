using System;
using Domain.Validations.Building;

namespace Domain.Commands.Building
{
    public class UpdateBuildingCommand: BuildingCommand
    {
        public UpdateBuildingCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public override bool IsValid()
        {
            ValidationResult = new UpdateBuildingCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}