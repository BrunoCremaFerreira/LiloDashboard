using LiloDash.Domain.Commands.Building;

namespace LiloDash.Domain.Validations.Building
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