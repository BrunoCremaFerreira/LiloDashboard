using Domain.Commands.User;

namespace Domain.Validations.User
{
    public class RemoveUserCommandValidation: UserValidation<UserCommand>
    {
        public RemoveUserCommandValidation()
        {
            ValidateId();
        }
    }
}