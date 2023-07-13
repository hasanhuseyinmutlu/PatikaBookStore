using FluentValidation;
using WebApi.BooksOperations.DeleteBook;
using WebApi.BooksOperations.GetBook;

namespace WebApi.BooksOperations.CreateBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator(){
            RuleFor(command => command.bookId).GreaterThan(0);
        }
    }
}