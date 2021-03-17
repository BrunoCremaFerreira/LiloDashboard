using System;
using System.Collections.Generic;
using System.Security.Claims;
using LiloDash.Domain.Interfaces.Model;
using LiloDash.Domain.Core.Models;

namespace LiloDash.Domain.Model
{
    /// <summary>
    /// System User Entity
    /// </summary>
    public class User: Entity, IUser
    {
        #region :: Constructors

        public User(Guid id, string name, string email, bool isAdmin)
        {
            Id = id;
            Name = name;
            Email = email;
            IsAdmin = isAdmin;
        }
        
        #endregion

        public string Name { get; private set; }
        
        public string Email { get; private set; }

        public bool IsAdmin { get; private set; }

        public bool IsAuthenticated()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            throw new NotImplementedException();
        }
        
    }
}