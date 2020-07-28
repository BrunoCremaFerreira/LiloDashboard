using System;
using System.Collections.Generic;
using LiloDash.Domain.Core.Events;

namespace Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}