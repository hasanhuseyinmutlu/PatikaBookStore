using WebApi.DBOperation;

namespace WebApi.Aplication.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }

        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            var authorBook = _context.Books.SingleOrDefault(b => b.Id == AuthorId);
            if (authorBook is not null)
                throw new InvalidOperationException("First you're need to remove book");

            if(author is null)
                throw new InvalidOperationException("Böyle bir yazar bulunmmaktadır ");
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}