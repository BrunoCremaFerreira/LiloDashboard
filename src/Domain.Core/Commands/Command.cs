using System;
using FluentValidation.Results;
using MediatR;

namespace LiloDash.Domain.Core.Commands
{
    ///<summary>
    /// Base class for system commands
    ///</summary>
    public abstract class Command : IRequest<ValidationResult>, IBaseRequest
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
