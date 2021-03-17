using System.Threading.Tasks;
using FluentValidation.Results;

namespace LiloDash.Domain.CommandHandlers
{
    public class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> Commit(Interfaces.IUnitOfWork uow, string message)
        {
            if (!await uow.Commit()) 
                AddError(message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(Interfaces.IUnitOfWork uow)
        {
            return await Commit(uow, "There was an error saving data").ConfigureAwait(false);
        }
    }
}