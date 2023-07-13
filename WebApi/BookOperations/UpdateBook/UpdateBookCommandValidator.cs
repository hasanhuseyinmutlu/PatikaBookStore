using FluentValidation;
namespace WebApi.BooksOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0).IsInEnum();
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(1);
        }
    }
}