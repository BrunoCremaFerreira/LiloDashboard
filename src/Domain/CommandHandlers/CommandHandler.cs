using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace LiloDash.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult = new ValidationResult();

        protected CommandHandler(){ }

        protected ValidationResult AddError(int errCode, string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem)
            {
                ErrorCode = errCode.ToString("X")
            });
            return ValidationResult;
        }

        protected ValidationResult AddError<TEntity, TKey>(TEntity entity, Expression<Func<TEntity, TKey>> propertyKey, string message)
            where TEntity : class
        {
            var expression = propertyKey.Body as MemberExpression;
            var propertyName = expression.Member.Name;
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, message));

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(Interfaces.IUnitOfWork uow, string message)
        {
            if (!await uow.Commit()) 
                AddError(0xC0001, message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(Interfaces.IUnitOfWork uow)
            =>  await Commit(uow, "There was an error saving data")
                    .ConfigureAwait(false);
    }
}