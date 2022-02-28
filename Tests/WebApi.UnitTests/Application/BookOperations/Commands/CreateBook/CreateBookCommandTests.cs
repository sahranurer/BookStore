using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.GetBooks;
using WebApi.DbOperations;
using WebApi.Entities;
using Xunit;
using static WebApi.Application.BookOperations.Commands.GetBooks.CreateBookCommand;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>{
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture){
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn(){
            //arrange hazırlık
            var book = new Book(){Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",PageCount=100,PublishDate= new System.DateTime(1990,01,10),GenreId = 1,AuthorId=1};
            _context.Books.Add(book);
            _context.SaveChanges();


            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model = new CreateBookModel(){Title = book.Title} ;

            //act çalıştırma
            //assert doğrulama
            FluentActions
              .Invoking(() => command.Handle())
              .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");


        }


            [Fact] // Happy Path
        public void Fact_WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            // arrange (Hazirlama)
            CreateBookCommand command = new(_context, _mapper);
            command.Model = new CreateBookModel() { Title = "Book", PageCount = 100, PublishDate = DateTime.Now.Date.AddYears(-2), GenreId = 1, AuthorId = 1 };

            // act (Calistirma)
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            // assert (Dogrulama)
            var addedBook = _context.Books.FirstOrDefault(x => x.Title == command.Model.Title && x.GenreId == command.Model.GenreId && x.AuthorId == command.Model.AuthorId);
            addedBook.Should().NotBeNull();
            addedBook.PageCount.Should().Be(command.Model.PageCount);
            addedBook.PublishDate.Should().Be(command.Model.PublishDate);
        }
        
    }
}