using AutoMapper;
using WebApi.Application.AuthorOperations;
using WebApi.Application.AuthorOperations.Commands;
using WebApi.Application.GenreOperations.Queries;
using WebApi.Application.GenreOperations.Queries.GetGenresDetailQuery;
using WebApi.Application.GenreOperations.Queries.GetGenresQuery;
using WebApi.Application.UserOperations.Commands.CreateUsers;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.GetBookDetail.GetBookDetailQuery;
using static WebApi.Application.BookOperations.Commands.GetBooks.CreateBookCommand;
using static WebApi.Application.BookOperations.Commands.GetBooks.GetBooksQuery;
using static WebApi.Application.UserOperations.Commands.CreateUsers.CreateUserCommand;

namespace WebApi.Common{
    public class MappingProfile : Profile{
       public MappingProfile(){
          
          CreateMap<CreateBookModel,Book>();
          CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre,
          opt=>opt.MapFrom(src=>src.Genre.Name));
          CreateMap<Book,BookViewModel>()
          .ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name))
          .ForMember(dest=>dest.Author,opt=>opt.MapFrom(src=>src.Author.Name));
          
          CreateMap<Genre,GenresViewModel>();
          CreateMap<Genre,GenreDetailViewModel>();


          CreateMap<Author,AuthorViewModel>();
          CreateMap<Author, AuthorDetailViewModel>();
          CreateMap<CreateAuthorModel,Author>();

          CreateMap<CreateUserModel, User>();
          
          
       
       
       }
    }
}