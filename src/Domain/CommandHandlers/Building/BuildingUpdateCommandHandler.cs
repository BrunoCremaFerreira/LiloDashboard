using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using LiloDash.Domain.Commands.Building;
using LiloDash.Domain.Interfaces.Repository.Data;
using MediatR;

namespace LiloDash.Domain.CommandHandlers.Building
{
    public class BuildingUpdateCommandHandler: CommandHandler, IRequestHandler<BuildingUpdateCommand, ValidationResult>
    {
        protected readonly IBuildingRepository _buildingRepository;

        public BuildingUpdateCommandHandler(IBuildingRepository buildingRepository)
            => _buildingRepository = buildingRepository;
        
        /// <summary>
        /// Handle Building Update Command
        /// </summary>
        public async Task<ValidationResult> Handle(BuildingUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            
            var buildingDb = await _buildingRepository.GetById(request.Id);
            
            if(buildingDb == null)
                return AddError(request, e => e.Id, "Building not found!");

            buildingDb.Name = request.Name;
            _buildingRepository.Update(buildingDb);

            return await Commit(_buildingRepository.UnitOfWork);
        }
    }
}