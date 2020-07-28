using LiloDash.Domain.Commands.Building;

namespace LiloDash.Domain.Validations.Building
{
    public class RemoveBuildingCommandValidation: BuildingValidation<BuildingCommand>
    {
        public RemoveBuildingCommandValidation()
        {
            ValidateId();
        }
    }
}