using LiloDash.Domain.Commands.Building;

namespace LiloDash.Domain.Validations.Building
{
    public class BuildingUpdateCommandValidation: BuildingValidation<UpdateBuildingCommand>
    {
        public BuildingUpdateCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}