using AutoMapper;
using WebApi.DBOperation;

namespace WebApi.Application.AuthorOperations.Queries
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;

        public GetAuthorsQuery(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<AuthorsViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.Id);
            List<AuthorsViewModel> obj = _mapper.Map<List<AuthorsViewModel>>(authors);
            return obj;
        }
    }
    public class AuthorsViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
