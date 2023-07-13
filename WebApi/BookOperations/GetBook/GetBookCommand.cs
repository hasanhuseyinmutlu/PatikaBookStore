

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperation;

namespace WebApi.BooksOperations.GetBook
{
    internal class GetBookCommand
    {
        public int bookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetBooksViewModel Handle()
        {

            var book = _dbContext.Books.Where(x => x.Id == bookId).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir Kitap bulunmuyor.");
            }
            GetBooksViewModel vm = _mapper.Map<GetBooksViewModel>(book);

            // GetBooksViewModel vm = new GetBooksViewModel();
            // vm.Title = book.Title;
            // vm.PageCount = book.PageCount;
            // vm.Genre = ((GenreEnum)book.GenreId).ToString();
            // vm.PublishDate = book.PublishDate.Date.ToString();
            return vm;
        }
    }

    public class GetBooksViewModel
    {
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; }
    }
}