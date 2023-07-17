using FluentAssertions;
using TestSetup;
using WebApi.Aplication.BooksOperations.UpdateBook;
using Xunit;
using static WebApi.Aplication.BooksOperations.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("The Shining", 0, 0)]
        [InlineData("", 0, 0)]
        [InlineData("", 0, 1)]
        [InlineData("", 100, 1)]
        [InlineData("Shini", 100, 1)]
        [InlineData("sh", 0, 1)]
        [InlineData("shin", 100, 0)]
        
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);

            command.Model = new UpdateBookModel()
            {
                Title = title,
                GenreId = genreId,
                PageCount = pageCount
            };

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var errors = validator.Validate(command);
            errors.Errors.Count.Should().BeGreaterThan(0);
        }
         [Theory]
        [InlineData("The Shining", 100, 1)]
        public void WhenValidDataGiven_Validator_ShouldNotBeReturnError(string title, int pageCount, int genreId)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);

             command.Model = new UpdateBookModel()
            {
                Title = title,
                GenreId = genreId,
                PageCount = pageCount
            };
            

            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }

}