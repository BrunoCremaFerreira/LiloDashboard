using System;
using LiloDash.Domain.Validations.User;

namespace LiloDash.Domain.Commands.User
{
    public class RemoveUserCommand: UserCommand
    {
        public RemoveUserCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}