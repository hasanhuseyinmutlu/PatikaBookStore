using FluentValidation;

namespace WebApi.Aplication.BooksOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator(){
            RuleFor(command => command.bookId).GreaterThan(0);
        }
    }
}