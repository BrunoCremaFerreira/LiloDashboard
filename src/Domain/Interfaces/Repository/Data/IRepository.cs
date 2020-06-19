using System;
using System.Linq;

namespace Domain.Interfaces.Repository.Data
{
    public interface IRepository<TEntity>: IDisposable where TEntity: class
    {
        TEntity GetById(Guid id);
        
        IQueryable<TEntity> GetAll();

        void Add(TEntity objs);
        
        void Update(TEntity obj);

        void Remove(Guid id);

        int SaveChanges();
    }
}