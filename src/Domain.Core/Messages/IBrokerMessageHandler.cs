using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using LiloDash.Domain.Core.Models;
using MediatR;

namespace LiloDash.Domain.Core.Messages
{
    public interface IBrokerMessageHandler<in TRequest>
        where TRequest : BrokerMessage 
    {
        Task Handle(TRequest request);
    }

    public interface IBrokerMessageHandler<in TRequest, TResponse>
        where TRequest : BrokerMessage 
        where TResponse : BrokerMessageResponse
    {
        Task<TResponse> Handle(TRequest request);
    }
}
