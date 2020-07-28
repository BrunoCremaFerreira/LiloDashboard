using LiloDash.Domain.Commands.User;

namespace LiloDash.Domain.Validations.User
{
    public class RegisterNewUserCommandValidation: UserValidation<RegisterNewUserCommand>
    {
        public RegisterNewUserCommandValidation()
        {
            ValidateName();
            ValidateEmail();
        }
    }
}