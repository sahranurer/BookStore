using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.Application.BookOperations.Commands.GetBookDetail;
using WebApi.Application.BookOperations.Commands.GetBooks;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.BookOperations.Commands.CreateBook;
using static WebApi.Application.BookOperations.Commands.GetBookDetail.GetBookDetailQuery;
using static WebApi.Application.BookOperations.Commands.GetBooks.CreateBookCommand;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
           
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                query.BookId = id;


                result = query.Handle();
            
          

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            
                command.Model = newBook;

                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                ValidationResult result = validator.Validate(command);
                validator.ValidateAndThrow(command);
                command.Handle();

               





            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
        {

            
                UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                ValidationResult result = validator.Validate(command);
                validator.ValidateAndThrow(command);
                command.BookId = id;
                command.Model = updateBook;
                command.Handle();
            


            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
           
                DeleteBookCommand command = new DeleteBookCommand(_context,_mapper);
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();

                validator.ValidateAndThrow(command);
                command.BookId = id;
               
                command.Handle();
            

            return Ok();
        }



    }


}
