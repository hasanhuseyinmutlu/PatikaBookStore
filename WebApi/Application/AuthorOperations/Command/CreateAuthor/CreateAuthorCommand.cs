using AutoMapper;
using WebApi.DBOperation;
using WebApi.Entities;

namespace WebApi.Aplication.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorViewModel Model { get; set; }

        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;

        public CreateAuthorCommand(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name);

            if (author is not null)
                throw new InvalidOperationException("Böyle bir yazar mevcut");

            author = _mapper.Map<Author>(Model);

            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }    

    public class CreateAuthorViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDay { get; set; }

    }
}