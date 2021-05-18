using System;
using FluentValidation.Results;
using LiloDash.Domain.Core.Models;
using MediatR;

namespace LiloDash.Domain.Core.Messages
{
    ///<summary>
    /// Base class for a broker message response
    ///</summary>
    public abstract class BrokerMessageResponse : BrokerMessage
    {
        public ValidationResult ValidationResult { get; set; }
    }
}