using System;
using LiloDash.Domain.Validations.Building;

namespace LiloDash.Domain.Commands.Building
{
    public class BuildingAddCommand: BuildingCommand
    {
        public BuildingAddCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewBuildingCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}