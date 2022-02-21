using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Commands.GetBookDetail{
    public class GetBookDetailQuery{
        private readonly BookStoreDbContext _dbContext;

        private readonly IMapper _mapper;
        public int BookId {get;set;}  
        public GetBookDetailQuery(BookStoreDbContext dbContext,IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }
       
       public BookDetailViewModel Handle(){
            var book = _dbContext.Books.Include(x=>x.Genre).SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                 throw new InvalidOperationException("Kitap zaten yok");
            }
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            
            return vm;
       }


       public class BookDetailViewModel{
           public string Title { get; set; }
           public string Genre { get; set; }
           public int PageCount { get; set; }
           
           public string PublishDate { get; set; }

       }

    }
}