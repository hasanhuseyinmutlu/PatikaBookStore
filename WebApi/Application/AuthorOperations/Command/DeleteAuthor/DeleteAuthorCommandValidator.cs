using FluentValidation;
using WebApi.Aplication.AuthorOperations.Command.DeleteAuthor;

namespace WebApi.Application.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}