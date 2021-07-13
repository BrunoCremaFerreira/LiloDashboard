using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using LiloDash.Domain.Commands.Building;
using LiloDash.Domain.Interfaces.Repository.Data;
using MediatR;

namespace LiloDash.Domain.CommandHandlers.Building
{
    public class BuildingRemoveCommandHandler: CommandHandler, IRequestHandler<BuildingRemoveCommand, ValidationResult>
    {
        protected readonly IBuildingRepository _buildingRepository;

        public BuildingRemoveCommandHandler(IBuildingRepository buildingRepository)
            => _buildingRepository = buildingRepository;
        
        /// <summary>
        /// Handle Remove Building Command
        /// </summary>
        public async Task<ValidationResult> Handle(BuildingRemoveCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            if(!_buildingRepository.Exists(e=> e.Id == request.Id))
                return AddError(request, e => e.Id, "Building not found!");

            _buildingRepository.Remove(request.Id);

            return await Commit(_buildingRepository.UnitOfWork);
        }
    }
}