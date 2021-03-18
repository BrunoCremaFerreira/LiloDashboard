using LiloDash.Domain.Core.Bus;
using LiloDash.Domain.Core.Commands;
using System.Threading.Tasks;
using MediatR;

namespace LiloDash.Infra.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        
        public InMemoryBus(IMediator mediator)
            => _mediator = mediator;
        
        public Task SendCommand<T>(T command) where T : Command
            => _mediator.Send(command);
    }
}
