using System;
using System.Linq;
using System.Linq.Expressions;
using LiloDash.Domain.Core.Models;

namespace LiloDash.Domain.Interfaces.Repository.Data
{
    public interface IRepository<TEntity>: IRepository 
        where TEntity: IEntity
    {
        IUnitOfWork UnitOfWork { get; }

        bool Exists(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IRepository: IDisposable
    {
    }
}