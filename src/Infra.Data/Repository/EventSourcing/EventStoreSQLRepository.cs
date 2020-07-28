using System;
using System.Collections.Generic;
using LiloDash.Domain.Core.Events;

namespace LiloDash.Infra.Data.Repository.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        public void Store(StoredEvent theEvent)
        {
            throw new NotImplementedException();
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}