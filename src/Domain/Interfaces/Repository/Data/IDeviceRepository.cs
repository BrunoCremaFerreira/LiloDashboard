using System;
using System.Threading.Tasks;
using LiloDash.Domain.Model;

namespace LiloDash.Domain.Interfaces.Repository.Data
{
    ///<summary>
    /// Device Repository
    ///</summary>
    public interface IDeviceRepository
    {
        void Add(Device device);

        void Update(Device device);

        void Remove(Guid Id);

        Task<Device> GetById(Guid id);
    }
}