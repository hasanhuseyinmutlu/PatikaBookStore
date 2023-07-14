using FluentValidation;
using WebApi.Aplication.AuthorOperations.Command.CreateAuthor;

namespace WebApi.Application.AuthorOperations.Command.CreateAuthor
{
   public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(Command => Command.Model.Name).NotEmpty().NotNull().Length(2,10);
            RuleFor(Command => Command.Model.Surname).NotEmpty().NotNull().Length(2,10);
            RuleFor(Command =>Command.Model.BirthDay).LessThan(DateTime.Now.Date);
        }
    }
}