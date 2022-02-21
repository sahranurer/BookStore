using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenresDetailQuery
{
    public class GetGenresDetailQuery
    {
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _dbContext;

        public readonly IMapper _mapper;

        public GetGenresDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if(genre is null){
                throw new InvalidOperationException("Kitap Türü Bulunmadı.");
            }
            return _mapper.Map<GenreDetailViewModel>(genre);
        }

    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}