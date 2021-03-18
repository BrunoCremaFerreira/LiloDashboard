using System;
using LiloDash.Domain.Validations.Building;

namespace LiloDash.Domain.Commands.Building
{
    public class BuildingUpdateCommand: BuildingCommand
    {
        public BuildingUpdateCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public override bool IsValid()
        {
            ValidationResult = new BuildingUpdateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}