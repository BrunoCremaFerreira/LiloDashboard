using LiloDash.Domain.Commands.User;

namespace LiloDash.Domain.Validations.User
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