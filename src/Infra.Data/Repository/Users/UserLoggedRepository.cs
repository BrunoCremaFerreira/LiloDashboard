using System;
using Microsoft.AspNetCore.Http;
using LiloDash.Domain.Interfaces.Repository.Data.Users;
using System.Security.Claims;

namespace LiloDash.Infra.Data.Repository.Users
{
    public class UserLoggedRepository : IUserLoggedRepository
    {
        private readonly IHttpContextAccessor _contextAcessor;

        public UserLoggedRepository(IHttpContextAccessor contextAcessor)
            => _contextAcessor = contextAcessor;    
        
        public Guid GetUserId()
        {
            if(!IsAuthenticated())
                return Guid.Empty;
            
            Guid.TryParse(_contextAcessor.HttpContext?.User?.GetUserId(), out var userId);
            return userId;
        }

        public string GetUserName()
            => IsAuthenticated()
                ? _contextAcessor.HttpContext.User.Identity.Name
                : string.Empty;

        public string GetUserEmail()
        => IsAuthenticated()
                ? _contextAcessor.HttpContext.User.GetUserEmail()
                : string.Empty;

        public bool IsAuthenticated()
            => _contextAcessor?.HttpContext?
                .User?.Identity?.IsAuthenticated ?? false;
          
    }

    internal static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal source)
            => source?.FindFirst("sub")?.Value;

        public static string GetUserEmail(this ClaimsPrincipal source)
            => source?.FindFirst("email")?.Value;
    }
}