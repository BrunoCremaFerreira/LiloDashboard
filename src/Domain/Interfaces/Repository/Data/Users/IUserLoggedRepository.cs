using System;

namespace LiloDash.Domain.Interfaces.Repository.Data.Users
{
    public interface IUserLoggedRepository
    {
        Guid GetUserId();
        string GetUserName();
        string GetUserEmail();
    }
}