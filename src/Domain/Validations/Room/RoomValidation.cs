using System;
using FluentValidation;
using LiloDash.Domain.Commands.Room;

namespace LiloDash.Domain.Validations.Room
{
    public class RoomValidation<T>: AbstractValidator<T> where T: RoomCommand
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
    }
}