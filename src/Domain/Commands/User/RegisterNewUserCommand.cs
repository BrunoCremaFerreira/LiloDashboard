using LiloDash.Domain.Validations.User;

namespace LiloDash.Domain.Commands.User
{
    public class RegisterNewUserCommand: UserCommand
    {
        public RegisterNewUserCommand(string name, string email, bool isAdmin)
        {
            Name = name;
            Email = email;
            IsAdmin = isAdmin;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}