using System;
using System.Threading.Tasks;

namespace LiloDash.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}