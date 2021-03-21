using System;
using FluentValidation.Results;

namespace LiloDash.Application.ViewModels
{
    public class AddResultViewModel<TId>
    {
        public AddResultViewModel(ValidationResult result, TId id)
        {
            Id = id;
            Result = result;
        }

        public TId Id {get; protected set; }
        public ValidationResult Result {get;set;}
    }
}