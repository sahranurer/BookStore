using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations;
using WebApi.Application.AuthorOperations.Commands;
using WebApi.Application.AuthorOperations.Queries;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
          private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
          public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AuthorDetailViewModel result;
           
                GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
                GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();
                validator.ValidateAndThrow(query);
                query.AuthorId = id;


                result = query.Handle();
            
          

            return Ok(result);
        }

         [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newBook)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            
                command.Model = newBook;

                CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
                ValidationResult result = validator.Validate(command);
                validator.ValidateAndThrow(command);
                command.Handle();

               





            return Ok();
        }


          [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateBook)
        {

            
                UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
                 command.AuthorId = id;
                command.Model = updateBook;
                UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
                ValidationResult result = validator.Validate(command);
                validator.ValidateAndThrow(command);
               
                command.Handle();
            


            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
           
                DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
                DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();

                validator.ValidateAndThrow(command);
                command.AuthorId = id;
               
                command.Handle();
            

            return Ok();
        }


    }

}