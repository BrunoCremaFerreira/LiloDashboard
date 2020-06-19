using Domain.Commands.Building;

namespace Domain.Validations.Building
{
    public class RemoveBuildingCommandValidation: BuildingValidation<BuildingCommand>
    {
        public RemoveBuildingCommandValidation()
        {
            ValidateId();
        }
    }
}