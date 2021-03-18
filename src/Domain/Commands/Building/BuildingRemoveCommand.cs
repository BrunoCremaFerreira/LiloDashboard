using System;
using LiloDash.Domain.Validations.Building;

namespace LiloDash.Domain.Commands.Building
{
    public class BuildingRemoveCommand : BuildingCommand
    {
        public RemoveBuildingCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveBuildingCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}