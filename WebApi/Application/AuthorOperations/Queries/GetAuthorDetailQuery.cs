using AutoMapper;
using WebApi.DBOperation;

namespace WebApi.Application.AuthorOperations.Queries
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }

        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;

        public GetAuthorDetailQuery(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id == AuthorId);

            if(author is null)
                throw new InvalidOperationException("Böyle bir yazar bulunamamaktadır");
            return _mapper.Map<AuthorDetailViewModel>(author);
        }
    }

    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}