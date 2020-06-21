using Domain.Interfaces.Repository.Data;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repository.User
{
    public class UserRepository: Repository<Domain.Model.User>, IUserRepository
    {
        public UserRepository(LiloDataContext context)
            : base(context)
        {

        }

        public Domain.Model.User GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}