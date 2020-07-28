using LiloDash.Domain.Model;

namespace LiloDash.Domain.Interfaces.Repository.Data
{
    public interface IUserRepository: IRepository<User>
    {
        User GetByEmail(string email);
    }
}