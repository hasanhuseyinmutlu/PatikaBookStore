using FluentValidation;

namespace WebApi.Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(Command => Command.Model.Name).NotEmpty().NotNull();
            RuleFor(Command => Command.Model.Surname).NotEmpty().NotNull();
        }
    }
}