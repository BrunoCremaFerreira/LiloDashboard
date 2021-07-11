using System;
using LiloDash.Domain.Validations.Building;

namespace LiloDash.Domain.Commands.Building
{
    public class BuildingAddCommand: BuildingCommand
    {
        public BuildingAddCommand(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new BuildingAddCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}