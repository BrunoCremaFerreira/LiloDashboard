using System;
using Domain.Core.Commands;

namespace Domain.Commands.User
{
    public abstract class UserCommand: Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public bool IsAdmin { get; protected set; }
        
    }
}