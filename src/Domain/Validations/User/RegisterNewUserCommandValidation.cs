using Domain.Commands.User;

namespace Domain.Validations.User
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