using System;
using FluentValidation;
using Domain.Commands.Building;

namespace Domain.Validations.Building
{
    public class BuildingValidation<T>: AbstractValidator<T> where T: BuildingCommand
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