using AutoMapper;
using WebApi.DBOperation;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace BookStoreWebApi.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;
        public CreateTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == Model.email && x.Password == Model.Password);
            if(user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();

                return token;
            }
            else
                throw new InvalidOperationException("Kullanıcı Adı veya şifre Hatalı !");
        }
    }

    public class CreateTokenModel{
        public string email { get; set; }
        public string Password { get; set; }


    }
}