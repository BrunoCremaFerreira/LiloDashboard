using System.Collections.Generic;
using System.Security.Claims;

namespace Domain.Interfaces.Model
{
    public interface IUser
    {
        string Name { get; }
        
        bool IsAuthenticated();

        IEnumerable<Claim> GetClaimsIdentity();
    }
}
