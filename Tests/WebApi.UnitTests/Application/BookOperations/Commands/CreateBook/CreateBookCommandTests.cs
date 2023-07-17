using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Aplication.BooksOperations.CreateBook;
using WebApi.DBOperation;
using WebApi.Entities;
using Xunit;
using static WebApi.Aplication.BooksOperations.CreateBook.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests :IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGive_InvalidOperationExceptiion_ShouldBeReturn()
        {
            //arrange
            var book = new Book(){Title ="WhenAlreadyExistBookTitleIsGive_InvalidOperationExceptiion_ShouldBeReturn",PageCount=100, PublishDate = new System.DateTime(1998,12,1), GenreId = 1};
            _context.Add(book);
            _context.SaveChanges();
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model = new CreateBookModel() {Title = book.Title};

            
            //act

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");


            //assert
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            CreateBookModel model = new CreateBookModel() {Title = "Ghost Runner", PageCount = 1000, PublishDate = DateTime.Now.Date.AddYears(-30),GenreId =1};
            command.Model = model;

            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
            book.GenreId.Should().Be(model.GenreId);

        }
    }
}