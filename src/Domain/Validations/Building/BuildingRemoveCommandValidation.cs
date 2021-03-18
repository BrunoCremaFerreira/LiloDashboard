using LiloDash.Domain.Commands.Building;

namespace LiloDash.Domain.Validations.Building
{
    public class BuildingRemoveCommandValidation: BuildingValidation<BuildingCommand>
    {
        public BuildingRemoveCommandValidation()
            => ValidateId();
    }
}