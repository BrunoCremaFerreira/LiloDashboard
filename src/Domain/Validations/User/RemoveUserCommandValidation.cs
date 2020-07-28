using LiloDash.Domain.Commands.User;

namespace LiloDash.Domain.Validations.User
{
    public class RemoveUserCommandValidation: UserValidation<UserCommand>
    {
        public RemoveUserCommandValidation()
        {
            ValidateId();
        }
    }
}