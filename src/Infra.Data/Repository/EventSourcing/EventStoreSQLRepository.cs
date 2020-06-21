using System;
using System.Collections.Generic;
using Domain.Core.Events;

namespace Data.Repository.EventSourcing
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