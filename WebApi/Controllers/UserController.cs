using AutoMapper;
using BookStoreWebApi.Application.UserOperations.Commands.Create;
using BookStoreWebApi.Application.UserOperations.Commands.CreateToken;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.UserOperations.Commands.RefreshToken;
using WebApi.DBOperation;
using WebApi.TokenOperations.Models;

namespace WebApi.Controlles
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        readonly IConfiguration _configuration;

        public UserController(IBookStoreDbContext context,IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = newUser;
            command.Handle();

            return Ok();
        }

        [HttpPost("connect/token")]

        public ActionResult<Token> CreateToken([FromBody]CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }
        
        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }
    }
}