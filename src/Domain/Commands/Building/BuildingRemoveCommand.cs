using System;
using LiloDash.Domain.Validations.Building;

namespace LiloDash.Domain.Commands.Building
{
    public class BuildingRemoveCommand : BuildingCommand
    {
        public BuildingRemoveCommand(Guid id)
            => Id = id;
        
        public override bool IsValid()
        {
            ValidationResult = new BuildingRemoveCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}