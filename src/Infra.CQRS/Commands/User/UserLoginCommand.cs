using System;

namespace CQRS.Commands.User
{
    /// <summary>
    /// CQRS command class for login procedure
    /// </summary>
    public class UserLoginCommand
    {
        public UserLoginCommand()
        {
        }

        public UserLoginCommand(string username, string password)
            : this()
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
