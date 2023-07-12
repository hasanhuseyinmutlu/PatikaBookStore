

using WebApi.Common;
using WebApi.DBOperation;

namespace WebApi.BooksOperations.GetBook
{
    internal class GetBookCommand
    {
        public int bookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public GetBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GetBooksViewModel Handle()
        {

            var book = _dbContext.Books.Where(x => x.Id == bookId).SingleOrDefault();

            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir Kitap bulunmuyor.");
            }

            GetBooksViewModel vm = new GetBooksViewModel();
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            vm.PublishDate = book.PublishDate.Date.ToString();
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