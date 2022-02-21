using AutoMapper;
using WebApi.Application.GenreOperations.Queries;
using WebApi.Application.GenreOperations.Queries.GetGenresDetailQuery;
using WebApi.Application.GenreOperations.Queries.GetGenresQuery;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.GetBookDetail.GetBookDetailQuery;
using static WebApi.Application.BookOperations.Commands.GetBooks.CreateBookCommand;
using static WebApi.Application.BookOperations.Commands.GetBooks.GetBooksQuery;

namespace WebApi.Common{
    public class MappingProfile : Profile{
       public MappingProfile(){
          CreateMap<CreateBookModel,Book>();
          CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre,
          opt=>opt.MapFrom(src=>src.Genre.Name));
          CreateMap<Book,BookViewModel>().ForMember(dest=>dest.Genre,
          opt=>opt.MapFrom(src=>src.Genre.Name));
          CreateMap<Genre,GenresViewModel>();
          CreateMap<Genre,GenreDetailViewModel>();
          
          
       
       
       }
    }
}