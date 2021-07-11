
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LiloDash.Domain.Core.Models;
using LiloDash.Domain.Interfaces;
using LiloDash.Infra.Data.Context;

namespace LiloDash.Infra.Data.Repository
{
    public abstract class RepositoryBase : IDisposable
    {

        protected readonly LiloDataContext Context;

        public IUnitOfWork UnitOfWork => Context;

        public RepositoryBase(LiloDataContext context)
            => Context = context;

        protected virtual bool Exists<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
            => Context.Set<TEntity>().Any(predicate);

        protected virtual void Add<TEntity>(IEntity entity)
            where TEntity : IEntity
        {
            entity.WhenCreated = DateTime.UtcNow;
            Context.Add((TEntity)entity);
        }

        protected async virtual Task AddAsync<TEntity>(IEntity entity)
            where TEntity : IEntity
        {
            entity.WhenCreated = DateTime.UtcNow;
            await Context.AddAsync((TEntity)entity);
        }

        protected virtual void Update<TEntity>(IEntity entity)
            where TEntity : IEntity
        {
            entity.WhenUpdated = DateTime.UtcNow;
            Context.Update((TEntity)entity);
        }

        protected virtual TEntity FindFirst<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
            => Context.Set<TEntity>().FirstOrDefault(predicate);

        public virtual void Dispose()
            => Context.Dispose();
    }
}
