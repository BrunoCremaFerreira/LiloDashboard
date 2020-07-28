using MediatR;
using Domain.Interfaces;
using LiloDash.Domain.Core.Bus;
using LiloDash.Domain.Core.Commands;
using LiloDash.Domain.Core.Notifications;

namespace Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediatorHandler _imediatorHandlerBus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _unitOfWork = unitOfWork;
            _notifications = (DomainNotificationHandler)notifications;
            _imediatorHandlerBus = bus;
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_unitOfWork.Commit()) return true;

            _imediatorHandlerBus.RaiseEvent(new DomainNotification("Commit", "An error occurred to save data!"));
            return false;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
                _imediatorHandlerBus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
        }
    }
}