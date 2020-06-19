using System;
using Domain.Validations.Building;

namespace Domain.Commands.Building
{
    public class RemoveBuildingCommand : BuildingCommand
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