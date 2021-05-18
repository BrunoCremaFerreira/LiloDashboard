using System;
using FluentValidation.Results;
using LiloDash.Domain.Core.Models;
using MediatR;

namespace LiloDash.Domain.Core.Messages
{
    ///<summary>
    /// Base class for Broker Message
    ///</summary>
    public abstract class BrokerMessage : Entity
    {
    }
}