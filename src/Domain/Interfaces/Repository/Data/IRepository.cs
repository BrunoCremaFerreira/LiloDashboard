using System;
using System.Linq;

namespace LiloDash.Domain.Interfaces.Repository.Data
{
    public interface IRepository<TEntity>: IRepository 
        where TEntity: class
    {
        IUnitOfWork UnitOfWork { get; }
    }

    public interface IRepository: IDisposable
    {
    }
}