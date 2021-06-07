using System;
using FluentValidation.Results;
using MediatR;

namespace LiloDash.Domain.Core.Commands
{
    ///<summary>
    /// Base class for system commands
    ///</summary>
    public abstract class Command<TResponse> : ICommand, IRequest<TResponse>, IBaseRequest
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }

    public abstract class Command : Command<ValidationResult>
    {
    }
}
