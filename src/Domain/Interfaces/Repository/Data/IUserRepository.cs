using Domain.Model;

namespace Domain.Interfaces.Repository.Data
{
    public interface IUserRepository: IRepository<User>
    {
        User GetByEmail(string email);
    }
}