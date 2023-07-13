using FluentValidation;
using WebApi.BooksOperations.GetBook;

namespace WebApi.BooksOperations.CreateBook
{
    public class GetBookCommandValidator : AbstractValidator<GetBookCommand>
    {
       public GetBookCommandValidator() 
        {
            RuleFor(command => command.bookId).GreaterThan(0);
        }
    }
}