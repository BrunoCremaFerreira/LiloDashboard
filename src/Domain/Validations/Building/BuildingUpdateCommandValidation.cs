using LiloDash.Domain.Commands.Building;

namespace LiloDash.Domain.Validations.Building
{
    public class BuildingUpdateCommandValidation: BuildingValidation<BuildingUpdateCommand>
    {
        public BuildingUpdateCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}