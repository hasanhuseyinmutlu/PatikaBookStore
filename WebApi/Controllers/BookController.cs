using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WebApi.addControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {   
        private static List<Book> BookList = new List<Book>() 
        {
            new Book
            {
                Id = 1,
                Title = "Mona Lisa Overdrive",
                GenreId = 1, // Science Fiction
                PageCount = 360,
                PublishDate = new DateTime(1988,06,12)
            },
            new Book
            {
                Id = 2,
                Title = "Count Zero",
                GenreId = 1, // Sciance Fiction
                PageCount = 256,
                PublishDate = new DateTime(1986,01,14)
            },
            new Book
            {
                Id = 3,
                Title = "Neuromancer",
                GenreId = 1, // Sciance Fiction
                PageCount = 271,
                PublishDate = new DateTime(1984,07,01)
            }
        };

        [HttpGet]
        public List<Book> GetBooks() 
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;

        }

        
        [HttpGet("{id}")]
        public Book GetById(int id) 
        {
            var bookId = BookList.Where(b => b.Id == id).SingleOrDefault();

            return bookId;
        }

        // [HttpGet]
        // public Book Get(string id) 
        // {
        //     var bookname = BookList.Where(n => n.Id == Convert.ToInt32(id)).SingleOrDefault();

        //     return bookname;
        // }

        //Post  

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook) {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);

            if (book is not null)
                return BadRequest();
            
                
            BookList.Add(newBook);
            return Ok();
        }

        //Put

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id,[FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);

            if (book is null)
            {
                return BadRequest();

            }
            // check database field, if it's changed (mean it is not 0) update else add new field 

            book.GenreId = updatedBook.GenreId != default  
            ? updatedBook.GenreId 
            : book.GenreId;

            book.PageCount = updatedBook.PageCount != default 
            ? updatedBook.PageCount 
            : book.PageCount;

            book.PublishDate = updatedBook.PublishDate != default
            ? updatedBook.PublishDate 
            : book.PublishDate;

            book.Title = updatedBook.Title != default
            ? updatedBook.Title 
            : book.Title;

            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return BadRequest();
            }

            BookList.Remove(book);
            return Ok();
        }

    } 
}