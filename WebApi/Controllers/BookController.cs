using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Aplication.BooksOperations.CreateBook;
using WebApi.Aplication.BooksOperations.DeleteBook;
using WebApi.Aplication.BooksOperations.GetBook;
using WebApi.Aplication.BooksOperations.UpdateBook;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.DBOperation;
using static WebApi.Aplication.BooksOperations.CreateBook.CreateBookCommand;
using static WebApi.Aplication.BooksOperations.UpdateBook.UpdateBookCommand;
namespace WebApi.Controlles
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);

            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBooksViewModel vmResult;
            GetBookCommandValidator commandValidator = new GetBookCommandValidator();
            GetBookCommand command = new GetBookCommand(_context, _mapper);

            command.bookId = id;


            commandValidator.ValidateAndThrow(command);

            vmResult = command.Handle();
            return Ok(vmResult);
        }

        // [HttpGet]
        // public Book Get(string id) 
        // {
        //     var bookname = BookList.Where(n => n.Id == Convert.ToInt32(id)).SingleOrDefault();

        //     return bookname;
        // }

        //Post  

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {

            CreateBookCommandValidator validator = new CreateBookCommandValidator();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);

            command.Model = newBook;

            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok(newBook);
        }

        //Put

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommandValidator commandValidator = new UpdateBookCommandValidator();
            UpdateBookCommand command = new UpdateBookCommand(_context);

            command.BookId = id;
            command.Model = updatedBook;

            commandValidator.Validate(command);
            commandValidator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();

            command.bookId = id;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

    }
}