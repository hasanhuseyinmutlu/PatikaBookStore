using WebApi.DBOperation;
using WebApi.Entities;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IConfiguration _configuration;
        public string RefreshToken;
        public RefreshTokenCommand(IBookStoreDbContext context, IConfiguration configuration)
        {
            _context = context;

            _configuration = configuration;
        }

        public Token Handle()
        {
            User user = _context.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user is not null)
            {

                TokenHandler handler = new TokenHandler(_configuration);

                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Valid Refresh Token Bulunamadı");
            }
        }
    }
}