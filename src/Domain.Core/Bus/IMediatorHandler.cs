using System.Threading.Tasks;
using Domain.Core.Commands;
using Domain.Core.Events;

namespace Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
