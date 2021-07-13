using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace LiloDash.Domain.CommandHandlers
{
    /// <summary>
    /// Base class for Command Handler
    /// </summary>
    public abstract class CommandHandler
    {
        /// <summary>
        /// Validation Result
        /// </summary>
        protected ValidationResult ValidationResult = new ValidationResult();

        protected CommandHandler(){ }

        /// <summary>
        /// Insert error in Validation Result with internal error code
        /// </summary>
        protected ValidationResult AddError(int errCode, string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem)
            {
                ErrorCode = errCode.ToString("X")
            });
            return ValidationResult;
        }

        /// <summary>
        /// Insert Validation Error
        /// </summary>
        protected ValidationResult AddError<TEntity, TKey>(TEntity entity, Expression<Func<TEntity, TKey>> propertyKey, string message)
            where TEntity : class
        {
            var expression = propertyKey.Body as MemberExpression;
            var propertyName = expression.Member.Name;
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, message));

            return ValidationResult;
        }

        /// <summary>
        /// Commit data
        /// </summary>
        protected async Task<ValidationResult> Commit(Interfaces.IUnitOfWork uow, string message)
        {
            if (!await uow.Commit()) 
                AddError(0xC0001, message);

            return ValidationResult;
        }

        /// <summary>
        /// Commit data
        /// </summary>
        protected async Task<ValidationResult> Commit(Interfaces.IUnitOfWork uow)
            =>  await Commit(uow, "There was an error saving data")
                    .ConfigureAwait(false);
    }
}