using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using LiloDash.Domain.Commands.Building;
using LiloDash.Domain.Interfaces.Repository.Data;
using MediatR;

namespace LiloDash.Domain.CommandHandlers.Building
{
    public class BuildingAddCommandHandler: CommandHandler, IRequestHandler<BuildingAddCommand, ValidationResult>
    {
        protected readonly IBuildingRepository _buildingRepository;

        public BuildingAddCommandHandler(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        /// <summary>
        /// Handle Register New Building Command
        /// </summary>
        public async Task<ValidationResult> Handle(BuildingAddCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            //TODO: Valid existing

            //_buildingRepository.Add();
            //return await Commit(_buildingRepository.UnitOfWork);
            throw new NotImplementedException();
        }
    }
}