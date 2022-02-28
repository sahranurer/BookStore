using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook{
    public class UpdateBookCommand{
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public UpdateBookModel Model { get; set; }

        public UpdateBookCommand(IBookStoreDbContext dbContext,IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
              var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı");
            }
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            
            _dbContext.SaveChanges();
        }



        public class UpdateBookModel{
            public string Title { get; set; }
            public int GenreId { get; set; }
        }

    }
}