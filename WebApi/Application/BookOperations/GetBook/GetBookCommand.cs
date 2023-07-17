

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperation;

namespace WebApi.Aplication.BooksOperations.GetBook
{
    public class GetBookCommand
    {
        public int bookId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetBookCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetBooksViewModel Handle()
        {

              var book = _context.Books
              .Include(x => x.Genre)
              .Include(x => x.Author)
              .SingleOrDefault(x => x.Id == bookId); 

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