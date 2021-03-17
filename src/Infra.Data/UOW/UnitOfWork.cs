using LiloDash.Infra.Data.Context;
using LiloDash.Domain.Interfaces;
using System.Threading.Tasks;

namespace LiloDash.Infra.Data.UOW
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly LiloDataContext _context;

        public UnitOfWork(LiloDataContext context)
            => _context = context;
            
        public async Task<bool> Commit()
            => await _context.SaveChangesAsync() > 0;
    }
}