using LiloDash.Domain.Core.Bus;
using LiloDash.Domain.Core.Commands;
using System.Threading.Tasks;
using MediatR;
using FluentValidation.Results;

namespace LiloDash.Infra.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        
        public InMemoryBus(IMediator mediator)
            => _mediator = mediator;
        
        public Task<ValidationResult> SendCommand<TCommand>(TCommand command) 
            where TCommand : Command
            => _mediator.Send(command);

        public Task<TResponse> SendCommand<TCommand, TResponse>(TCommand command) 
            where TCommand : Command<TResponse>
            => _mediator.Send(command);
    }
}
