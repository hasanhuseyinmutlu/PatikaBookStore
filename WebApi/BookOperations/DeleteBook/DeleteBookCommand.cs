using WebApi.DBOperation;

namespace WebApi.BooksOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public int bookId { get; set; }

        private readonly BookStoreDbContext _dbContext;

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(){

            var book = _dbContext.Books.SingleOrDefault(x => x.Id == bookId);
            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir Kitap yok");
                
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}