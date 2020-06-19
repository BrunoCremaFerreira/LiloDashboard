using System;
using Domain.Validations.User;

namespace Domain.Commands.User
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