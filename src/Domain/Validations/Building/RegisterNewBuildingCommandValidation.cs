using LiloDash.Domain.Commands.Building;

namespace LiloDash.Domain.Validations.Building
{
    public class RegisterNewBuildingCommandValidation: BuildingValidation<RegisterNewBuildingCommand>
    {
        public RegisterNewBuildingCommandValidation()
        {
            ValidateName();
        }
    }
}