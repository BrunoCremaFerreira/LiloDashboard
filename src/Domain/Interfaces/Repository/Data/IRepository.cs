using System;
using System.Linq;

namespace LiloDash.Domain.Interfaces.Repository.Data
{
    public interface IRepository<TEntity>: IDisposable 
        where TEntity: class
    {
        IUnitOfWork UnitOfWork {get;}
    }
}