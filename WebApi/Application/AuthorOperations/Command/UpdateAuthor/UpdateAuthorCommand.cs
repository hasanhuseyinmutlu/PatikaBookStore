using WebApi.DBOperation;

namespace WebApi.Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public UpdateAuthorModel Model { get; set; }

        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;

        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Böyle bir yazar bulunmamaktadır");
            // if(_context.Authors.Any(x => x.Name.ToLower()== Model.Name.ToLower() && x.Id != AuthorId));
            author.Name = Model.Name.Trim() == default
            ? author.Name
            : Model.Name;
            author.Surname = Model.Surname.Trim() == default
            ? author.Surname
            : Model.Surname;
            _context.SaveChanges();

        }
    }
    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}