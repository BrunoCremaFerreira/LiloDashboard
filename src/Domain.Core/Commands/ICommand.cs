using FluentValidation.Results;

namespace LiloDash.Domain.Core.Commands
{
    ///<summary>
    /// Base command Interface
    ///</summary>
    public interface ICommand
    {
        ValidationResult ValidationResult { get; set; }

        bool IsValid();
    }
}
