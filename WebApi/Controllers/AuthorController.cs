using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Aplication.AuthorOperations.Command.CreateAuthor;
using WebApi.Aplication.AuthorOperations.Command.DeleteAuthor;
using WebApi.Application.AuthorOperations.Command.CreateAuthor;
using WebApi.Application.AuthorOperations.Command.DeleteAuthor;
using WebApi.Application.AuthorOperations.Command.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries;
using WebApi.DBOperation;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        private readonly IMapper _mapper;

        public AuthorController(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        [HttpGet]
        public ActionResult GetAuthors()
        {

            GetAuthorsQuery query = new GetAuthorsQuery(_mapper,_context);

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorViewModel newAuthor)
        {

            CreateAuthorCommand command = new CreateAuthorCommand(_mapper,_context);

            command.Model = newAuthor;

            CreateAuthorCommandValidator createValid = new CreateAuthorCommandValidator();

            createValid.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]

        public IActionResult UpdateAuthor(int id,[FromBody]
        UpdateAuthorModel updateAuthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);

            command.Model = updateAuthor;
            command.AuthorId = id;

            UpdateAuthorCommandValidator updateValid = new UpdateAuthorCommandValidator();

            updateValid.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);

            command.AuthorId = id;

            DeleteAuthorCommandValidator deleteValid = new DeleteAuthorCommandValidator();

            deleteValid.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}