using System;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.GetBooks;
using WebApi.BookOperations.Commands.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;
using static WebApi.Application.BookOperations.Commands.GetBooks.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>{
        [Theory]
        [InlineData("Lord od the",0,0,0)]
         [InlineData("Lord od the",0,0,1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title,int pagecount,int genreId,int authorId){
            //arrange
            CreateBookCommand command = new CreateBookCommand(null,null);

            command.Model = new CreateBookModel(){
                Title = title,
                PageCount=pagecount,
                PublishDate=DateTime.Now.Date.AddYears(-1),
                GenreId=genreId,
                AuthorId=authorId
            };
//act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

           


        }
[Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError(){
  CreateBookCommand command = new CreateBookCommand(null,null);

            command.Model = new CreateBookModel(){
                Title = "Lord Of The Rings",
                PageCount= 100,
                PublishDate=DateTime.Now.Date,
                GenreId=1,
                AuthorId=1
            };

            CreateBookCommandValidator validator= new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenValidInoutAreGiven_Validator_ShouldNotBeReturnError(){
  CreateBookCommand command = new CreateBookCommand(null,null);

            command.Model = new CreateBookModel(){
                Title = "Lord Of The Rings",
                PageCount= 100,
                PublishDate=DateTime.Now.Date.AddYears(-2),
                GenreId=1,
                AuthorId=1
            };

            CreateBookCommandValidator validator= new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }



        
        
    }
}