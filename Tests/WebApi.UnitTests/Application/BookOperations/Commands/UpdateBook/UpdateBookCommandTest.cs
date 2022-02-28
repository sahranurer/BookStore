using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DbOperations;
using Xunit;
using static WebApi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;

namespace WebApi.UnitTests.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture> // Mapper ve Context'e erisimi saglar
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        //[InlineData(6)] -- passed
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void Theory_WhenNotExistedBookIdIsGiven_InvalidOperationException_ShouldBeReturn(int bookId)
        {
            // arrange (Hazirlama)
            UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);
            command.BookId = bookId;
            command.Model = new UpdateBookModel() { Title = "Book", GenreId = 2};

            // act & assert (Calistirma ve Dogrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("No book found to be updated!");
        }

        [Fact]
        public void Fact_WhenValidInputsAreGiven_Book_ShouldBeUpdated()
        {
            // arrange (Hazirlama)
            UpdateBookCommand command = new(_context, _mapper);
            command.BookId = 1;
           command.Model = new UpdateBookModel() { Title = "Book", GenreId = 2};


            // act (Calistirma)
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            // assert (Dogrulama)
            var updatedBook = _context.Books.FirstOrDefault(x => x.Id == command.BookId);
            updatedBook.Should().NotBeNull();
            updatedBook.Title.Should().Be(command.Model.Title);
           
            updatedBook.GenreId.Should().Be(command.Model.GenreId);
           
            updatedBook.PublishDate.Should().Be(updatedBook.PublishDate);
        }
/*
        [Fact]
        public void Fact_WhenValidDateTimeIsGiven_Book_ShouldBeUpdated()
        {
            // arrange (Hazirlama)
            UpdateBookCommand command = new(_context, _mapper);
            command.BookId = 1;
            command.Model = new UpdateBookModel() { PublishDate = DateTime.Now.Date.AddYears(-2) };

            // act (Calistirma)
            FluentActions
                .Invoking(() => command.Handle()).Invoke();

            // assert (Dogrulama)
            var updatedBook = _context.Books.FirstOrDefault(x => x.Id == command.BookId);
            updatedBook.Should().NotBeNull();
            updatedBook.Title.Should().Be(updatedBook.Title);
            updatedBook.AuthorId.Should().Be(updatedBook.AuthorId);
            updatedBook.GenreId.Should().Be(updatedBook.GenreId);
            updatedBook.PageCount.Should().Be(updatedBook.PageCount);
            updatedBook.PublishDate.Should().Be(command.Model.PublishDate);
        }
        */
    }
}