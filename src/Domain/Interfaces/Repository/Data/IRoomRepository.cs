using System;
using System.Threading.Tasks;
using LiloDash.Domain.Model;

namespace LiloDash.Domain.Interfaces.Repository.Data
{
    ///<summary>
    /// Room Repository
    ///</summary>
    public interface IRoomRepository
    {
        void Add(Room room);

        void Update(Room room);

        void Remove(Guid Id);

        Task<Room> GetById(Guid id);
    }
}