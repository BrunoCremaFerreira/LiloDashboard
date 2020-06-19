using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Domain.Commands.User;
using Domain.Events.User;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Data;
using Domain.Core.Bus;
using Domain.Core.Notifications;

namespace Domain.CommandHandlers.User
{
    public class UserCommandHandler: CommandHandler,
        IRequestHandler<RegisterNewUserCommand>,
        IRequestHandler<UpdateUserCommand>,
        IRequestHandler<RemoveUserCommand>
    {

        private readonly IMediatorHandler Bus;
        private readonly IUserRepository _userRepository;
        
        public UserCommandHandler(IUserRepository userRepository,
            IUnitOfWork unitOfWork, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications) : 
            base(unitOfWork, bus, notifications)
        {
            _userRepository = userRepository;
            Bus = bus;
        }

        /// <summary>
        /// Handle Register New User Command
        /// </summary>
        public Task Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.CompletedTask;
            }

            var user = new Model.User(Guid.NewGuid(), 
                request.Name, request.Email, request.IsAdmin);

            if (_userRepository.GetByEmail(request.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "The customer e-mail has already been used."));
                return Task.CompletedTask;
            }

            _userRepository.Add(user);

            if (Commit())
                Bus.RaiseEvent(new UserRegisteredEvent(user.Id, user.Name, user.Email, user.IsAdmin));
            
            return Task.CompletedTask;
        }

        /// <summary>
        /// Handle Update User Command
        /// </summary>
        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.CompletedTask;
            }
            
            var user = new Model.User(request.Id, 
                request.Name, request.Email, request.IsAdmin);
            var existingUser = _userRepository.GetByEmail(user.Email);
            
            if (existingUser != null && existingUser.Id != user.Id)
            {
                if (!existingUser.Equals(user))
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType,"The customer e-mail has already been used."));
                    return Task.CompletedTask;
                }
            }
            
            _userRepository.Update(user);
            
            if (Commit())
                Bus.RaiseEvent(new UserUpdatedEvent(user.Id, user.Name, user.Email, user.IsAdmin));
            
            return Task.CompletedTask;
        }

        /// <summary>
        /// Handle Remove User Command
        /// </summary>
        public Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.CompletedTask;
            }
            
            _userRepository.Remove(request.Id);
            
            if (Commit())
                Bus.RaiseEvent(new UserRemovedEvent(request.Id));
            
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}