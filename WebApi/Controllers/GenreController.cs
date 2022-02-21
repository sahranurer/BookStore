using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommandValidator;
using WebApi.Application.GenreOperations.Commands.DeleteGenre.DeleteGenreCommand;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenresDetailQuery;
using WebApi.Application.GenreOperations.Queries.GetGenresQuery;
using WebApi.DbOperations;
using static WebApi.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
            private readonly BookStoreDbContext _context;
            private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres(){

            GetGenresQuery query = new GetGenresQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj) ; 
        }


        [HttpGet("id")]
        public ActionResult GetGenreDetails(int id){

            GetGenresDetailQuery query = new GetGenresDetailQuery(_context,_mapper);
            query.GenreId = id;
            GetGenresDetailQueryValidator validator = new GetGenresDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj) ; 
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre){
 
           CreateGenreCommand command = new CreateGenreCommand(_context);
           command.Model = newGenre;

           CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
           validator.ValidateAndThrow(command);
           command.Handle();
           return Ok();
            
        }


        [HttpPut("id")]
        public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreModel updateGenre){
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.Model = updateGenre;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id){
           DeleteGenreCommand command = new DeleteGenreCommand(_context);
           command.GenreId = id;
           DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
           validator.ValidateAndThrow(command);
           command.Handle();
           return Ok();

        }



    }
}


