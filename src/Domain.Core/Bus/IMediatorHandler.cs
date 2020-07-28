using System.Threading.Tasks;
using LiloDash.Domain.Core.Commands;
using LiloDash.Domain.Core.Events;

namespace LiloDash.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
