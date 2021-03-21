using System.Threading.Tasks;
using FluentValidation.Results;
using LiloDash.Domain.Core.Commands;

namespace LiloDash.Domain.Core.Bus
{
    ///<summary>
    /// Mediator pattern Handler
    ///</summary>
    public interface IMediatorHandler
    {
        ///<summary>
        /// Send command to Mediator
        ///</summary>
        Task<ValidationResult> SendCommand<TCommand>(TCommand command) where TCommand : Command;
    }
}
