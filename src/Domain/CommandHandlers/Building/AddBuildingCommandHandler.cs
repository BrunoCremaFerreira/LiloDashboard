using System;

namespace LiloDash.Domain.CommandHandlers.Building
{
    public class AddBuildingCommandHandler: CommandHandler, IRequestHandler<RegisterNewBuildingCommand, ValidationResult>
    {
        protected readonly IBuildingRepository _buildingRepository;

        public AddBuildingCommandHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        /// <summary>
        /// Handle Register New Building Command
        /// </summary>
        public async Task<ValidationResult> Handle(AddBuildingCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            //TODO: Valid existing

            _buildingRepository.Add(building);
            return await Commit(_buildingRepository.UnitOfWork);
        }
    }
}