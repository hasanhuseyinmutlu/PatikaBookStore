using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Aplication.BooksOperations.GetBook;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.DBOperation;
using Xunit;

namespace Application.BookOperations.Commands.Queries
{
    public class GetBookDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailQueryTest(CommonTestFixture testFixture)
        {
            _mapper = testFixture.Mapper;
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenBookIdIsGiven_GetDetail_ShoulBeReturn()
        {
            //Arrenge
            GetBookCommand query = new GetBookCommand(_context, _mapper);
            query.bookId = 999;

            //Act & Assert (Calıstır & Doğrulama)
            FluentActions
            .Invoking(() => query.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Kitap Bulunamadı !");

        }

        [Fact]
        public void WhenValidInputBookIdGiven_Book_GetDetail()
        {
            //Arrenge
            GetBookCommand query = new GetBookCommand(_context, _mapper);
            GetBooksViewModel model = new GetBooksViewModel();
            query.bookId = 1;

            // Arc
            FluentActions.Invoking(() => query.Handle()).Invoke();

            //Assert
            var book = _context.Books.SingleOrDefault(book => book.Id == 1);
            book.Should().NotBeNull();

        }
    }
}