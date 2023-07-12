using Microsoft.AspNetCore.Mvc;
using WebApi.BooksOperations.CreateBook;
using WebApi.BooksOperations.DeleteBook;
using WebApi.BooksOperations.GetBook;
using WebApi.BooksOperations.UpdateBook;
using WebApi.DBOperation;
using static WebApi.BooksOperations.CreateBook.CreateBookCommand;
using static WebApi.BooksOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.addControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {  
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public IActionResult GetBooks() 
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            GetBooksViewModel vmResult;

            GetBookCommand command = new GetBookCommand(_context);
            try
            {
                command.bookId = id;
                
                vmResult = command.Handle();
                
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
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
        public IActionResult AddBook([FromBody] CreateBookModel newBook) {
        
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok(newBook);
        }

        //Put

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);

            try
            {
                command.bookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    } 
}