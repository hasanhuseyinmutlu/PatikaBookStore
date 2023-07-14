using FluentValidation;


namespace WebApi.Aplication.BooksOperations.GetBook
{
    public class GetBookCommandValidator : AbstractValidator<GetBookCommand>
    {
       public GetBookCommandValidator() 
        {
            RuleFor(command => command.bookId).GreaterThan(0);
        }
    }
}