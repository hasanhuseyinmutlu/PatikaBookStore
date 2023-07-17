using FluentAssertions;
using TestSetup;
using WebApi.Aplication.BooksOperations.DeleteBook;
using WebApi.DBOperation;
using Xunit;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteBookCommandTest(BookStoreDbContext context)
        {
            _context = context;
        }

        private int bookId { get; set; }

        [Fact]
        public void WhenGivenIdIfNotExist_InvalidOperationException_ReturnError()
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.bookId = 4;

            FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message
            .Should().Be("Silinecek böyle bir kitap yok ");
        }

        [Fact]
        public void WhenGivenIdExist_Remove()
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.bookId = 1;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var book = _context.Books.SingleOrDefault(x => x.Id == command.bookId);
            book.Should().Be(null);


        }
    }
}