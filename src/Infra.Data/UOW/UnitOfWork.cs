using Data.Context;
using Domain.Interfaces;

namespace Data.UOW
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly LiloDataContext _context;

        public UnitOfWork(LiloDataContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}