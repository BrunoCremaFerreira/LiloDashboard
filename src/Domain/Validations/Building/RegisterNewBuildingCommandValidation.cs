using Domain.Commands.Building;

namespace Domain.Validations.Building
{
    public class RegisterNewBuildingCommandValidation: BuildingValidation<RegisterNewBuildingCommand>
    {
        public RegisterNewBuildingCommandValidation()
        {
            ValidateName();
        }
    }
}