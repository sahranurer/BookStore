using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.DbOperations;
using Xunit;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests: IClassFixture<CommonTestFixture>{ // Provides to access Mapper and Context


 private readonly BookStoreDbContext _context;
private readonly IMapper _mapper;

 public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Theory]
        //[InlineData(6)] -- passed
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void Theory_WhenNotExistedIdIsGiven_InvalidOperationException_ShouldBeReturn(int bookId)
        {
            // arrange (preparation) -- hazirlama
            DeleteBookCommand command = new(_context,_mapper);
            command.BookId = bookId;

            // act (run) & assert (defend) -- calistirma ve iddia etme
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("No book found to be deleted!");
        }

        [Fact]
        public void Fact_WhenValidIdIsGiven_Book_ShouldBeDeleted()
        {
            // arrange (preparation) -- hazirlama
            DeleteBookCommand command = new(_context,_mapper);
            command.BookId = 1;

            // act (run) -- calistirma
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // assert (defend) -- iddia etmek
            var deletedBook = _context.Books.FirstOrDefault(x => x.Id == command.BookId);
            deletedBook.Should().BeNull();
        }
    }
}