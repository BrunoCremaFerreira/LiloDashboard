using LiloDash.Domain.Commands.Building;

namespace LiloDash.Domain.Validations.Building
{
    public class BuildingAddCommandValidation: BuildingValidation<BuildingAddCommand>
    {
        public BuildingAddCommandValidation()
            => ValidateName();
    }
}