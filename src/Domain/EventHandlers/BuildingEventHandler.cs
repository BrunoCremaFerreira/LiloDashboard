using System.Threading;
using System.Threading.Tasks;
using Domain.Events.Building;
using MediatR;

namespace Domain.EventHandlers.Building
{
    public class BuildingEventHandler :
        INotificationHandler<BuildingRegisteredEvent>,
        INotificationHandler<BuildingUpdatedEvent>,
        INotificationHandler<BuildingRemovedEvent>
    {
        public Task Handle(BuildingUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }

        public Task Handle(BuildingRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            return Task.CompletedTask;
        }

        public Task Handle(BuildingRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail
            return Task.CompletedTask;
        }
    }
}