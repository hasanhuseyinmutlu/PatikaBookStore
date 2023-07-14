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

            if(author is null)
                throw new InvalidOperationException("Böyle bir yazar bulunmmaktadır ");
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}