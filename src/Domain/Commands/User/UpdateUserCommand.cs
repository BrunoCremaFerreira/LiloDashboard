using System;
using LiloDash.Domain.Validations.User;

namespace LiloDash.Domain.Commands.User
{
    public class UpdateUserCommand: UserCommand
    {
        public UpdateUserCommand(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        
        public override bool IsValid()
        {
            ValidationResult = new UpdateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}