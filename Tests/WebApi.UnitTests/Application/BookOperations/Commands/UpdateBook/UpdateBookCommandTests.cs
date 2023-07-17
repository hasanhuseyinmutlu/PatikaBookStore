using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Aplication.BooksOperations.UpdateBook;
using WebApi.DBOperation;
using Xunit;
using static WebApi.Aplication.BooksOperations.UpdateBook.UpdateBookCommand;

namespace Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _mapper = testFixture.Mapper;
            _context = testFixture.Context;

        }
        [Fact]

        public void WhenGivenIdIfNotExist_InvalidOperationException_ShouldBeReturnErrors()
        {
         
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = 4; 
           

            FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message
            .Should().Be("Güncellenecek Böyle bir kitap yok");
        }

        [Fact]

        public void WhenGivenIdIsExist_Book_ShouldBeUpdated()
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);

            UpdateBookModel model = new UpdateBookModel() {Title ="GivenBookIdInDb_ShouldBeUpdated",GenreId = 1,PageCount = 100};
            command.Model = model;
            command.BookId = 1;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var book = _context.Books.SingleOrDefault(b => b.Id == command.BookId);
            book.Should().NotBeNull();
        }
    }
}