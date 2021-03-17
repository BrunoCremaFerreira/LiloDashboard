using System.Threading.Tasks;
using LiloDash.Domain.Core.Commands;

namespace LiloDash.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
    }
}
