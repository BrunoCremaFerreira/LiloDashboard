using Domain.Commands.User;

namespace Domain.Validations.User
{
    public class UpdateUserCommandValidation: UserValidation<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateEmail();
        }
    }
}