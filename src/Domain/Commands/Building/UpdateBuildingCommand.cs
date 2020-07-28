using System;
using LiloDash.Domain.Validations.Building;

namespace LiloDash.Domain.Commands.Building
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