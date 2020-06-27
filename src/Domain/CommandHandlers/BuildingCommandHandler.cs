using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Data;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Domain.Commands.Building;
using System.Linq;
using Domain.Events.Building;

namespace Domain.CommandHandlers
{
    public class BuildingCommandHandler: CommandHandler,
        IRequestHandler<RegisterNewBuildingCommand>,
        IRequestHandler<UpdateBuildingCommand>,
        IRequestHandler<RemoveBuildingCommand>
    {

        private readonly IMediatorHandler Bus;
        private readonly IBuildingRepository _buildingRepository;
        
        public BuildingCommandHandler(IBuildingRepository buildingRepository,
            IUnitOfWork unitOfWork,
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) :
            base(unitOfWork, bus, notifications)
        {
            _buildingRepository = buildingRepository;
            Bus = bus;
        }

        /// <summary>
        /// Handle Register New Building Command
        /// </summary>
        public async Task<Unit> Handle(RegisterNewBuildingCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Unit.Value;
            }

            var building = new Model.Building(Guid.NewGuid(), request.Name);

            if (_buildingRepository.GetAll().Any(e=> e.Name.Trim().ToUpper() == request.Name.Trim().ToUpper()))
            {
                await Bus.RaiseEvent(new DomainNotification(request.MessageType, "The building name has already been used."));
                return Unit.Value;
            }

            _buildingRepository.Add(building);

            if (Commit())
                await Bus.RaiseEvent(new BuildingRegisteredEvent(building.Id, building.Name));
            
            return Unit.Value;
        }

        /// <summary>
        /// Handle Update Building Command
        /// </summary>
        public async Task<Unit> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Unit.Value;
            }
            
            var building = _buildingRepository.GetById(request.Id);
            if (building != null && building.Id != request.Id)
            {
                if (building.Name.Trim().ToUpper() == request.Name.Trim().ToUpper())
                {
                    await Bus.RaiseEvent(new DomainNotification(request.MessageType, "The building name has already been used."));
                    return Unit.Value;
                }
            }
            
            building.UpdateData(request);
            _buildingRepository.Update(building);
            
            if (Commit())
                await Bus.RaiseEvent(new BuildingUpdatedEvent(building.Id, building.Name));
            
            return Unit.Value;
        }

        /// <summary>
        /// Handle Remove building Command
        /// </summary>
        public async Task<Unit> Handle(RemoveBuildingCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Unit.Value;
            }
            
            _buildingRepository.Remove(request.Id);
            
            if (Commit())
                await Bus.RaiseEvent(new BuildingRemovedEvent(request.Id));
            
            return Unit.Value;
        }

        public void Dispose()
        {
            _buildingRepository.Dispose();
        }
    }
}