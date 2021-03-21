using System;
using System.Threading.Tasks;

namespace LiloDash.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        Task<bool> Commit();
    }
}