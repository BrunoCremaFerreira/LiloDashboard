using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using LiloDash.Domain.Model;

namespace LiloDash.Domain.Interfaces.Repository.Data
{
    ///<summary>
    /// Building Repository
    ///</summary>
    public interface IBuildingRepository
    {
        void Add(Building building);

        void Update(Building building);

        void Remove(Guid Id);

        Task<Building> GetById(Guid id);
    }
}