using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using LiloDash.Domain.Model;

namespace LiloDash.Domain.Interfaces.Repository.Data
{
    ///<summary>
    /// Building Repository
    ///</summary>
    public interface IBuildingRepository : IRepository<Building>
    {
        Task Add(Building building);

        void Update(Building building);

        void Remove(Guid Id);

        Task<Building> GetById(Guid id);
    }
}