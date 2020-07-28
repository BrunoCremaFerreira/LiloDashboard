using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using LiloDash.Domain.Commands.User;
using LiloDash.Domain.Events.User;
using LiloDash.Domain.Interfaces;
using LiloDash.Domain.Interfaces.Repository.Data;
using LiloDash.Domain.Core.Bus;
using LiloDash.Domain.Core.Notifications;

namespace LiloDash.Domain.CommandHandlers
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
        public async Task<Unit> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Unit.Value;
            }

            var user = new Model.User(Guid.NewGuid(), 
                request.Name, request.Email, request.IsAdmin);

            if (_userRepository.GetByEmail(request.Email) != null)
            {
                await Bus.RaiseEvent(new DomainNotification(request.MessageType, "The customer e-mail has already been used."));
                return Unit.Value;
            }

            _userRepository.Add(user);

            if (Commit())
                await Bus.RaiseEvent(new UserRegisteredEvent(user.Id, user.Name, user.Email, user.IsAdmin));
            
            return Unit.Value;
        }

        /// <summary>
        /// Handle Update User Command
        /// </summary>
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Unit.Value;
            }
            
            var user = new Model.User(request.Id, 
                request.Name, request.Email, request.IsAdmin);
            var existingUser = _userRepository.GetByEmail(user.Email);
            
            if (existingUser != null && existingUser.Id != user.Id)
            {
                if (!existingUser.Equals(user))
                {
                    await Bus.RaiseEvent(new DomainNotification(request.MessageType,"The customer e-mail has already been used."));
                    return Unit.Value;
                }
            }
            
            _userRepository.Update(user);
            
            if (Commit())
                await Bus.RaiseEvent(new UserUpdatedEvent(user.Id, user.Name, user.Email, user.IsAdmin));
            
            return Unit.Value;
        }

        /// <summary>
        /// Handle Remove User Command
        /// </summary>
        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Unit.Value;
            }
            
            _userRepository.Remove(request.Id);
            
            if (Commit())
                await Bus.RaiseEvent(new UserRemovedEvent(request.Id));
            
            return Unit.Value;
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}