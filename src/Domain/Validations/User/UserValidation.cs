using System;
using FluentValidation;
using LiloDash.Domain.Commands.User;

namespace LiloDash.Domain.Validations.User
{
    public abstract class UserValidation<T> : AbstractValidator<T> where T: UserCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        
        protected void ValidateName()
        {
            RuleFor(c => c.Name).
                NotEmpty().WithMessage("Name is not seted").
                Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
        
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email).
                NotEmpty().
                EmailAddress();
        }
    }
}