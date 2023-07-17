using FluentAssertions;
using TestSetup;
using WebApi.Aplication.BooksOperations.DeleteBook;
using Xunit;

namespace Application.BookOperations.Commands.DeleteBook
{
    
    public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
       public void  InvalidId_Validator_ReturnError(int id )
       {
        DeleteBookCommand command = new DeleteBookCommand(null);
        command.bookId = id;

        DeleteBookCommandValidator validation = new DeleteBookCommandValidator();

        var result = validation.Validate(command);

        result.Errors.Count.Should().BeGreaterThan(0);
       }
    }
}