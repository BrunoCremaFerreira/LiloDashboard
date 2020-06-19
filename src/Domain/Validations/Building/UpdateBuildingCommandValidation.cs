using Domain.Commands.Building;

namespace Domain.Validations.Building
{
    public class UpdateBuildingCommandValidation: BuildingValidation<UpdateBuildingCommand>
    {
        public UpdateBuildingCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}