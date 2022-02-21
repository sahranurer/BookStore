using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre.DeleteGenreCommand{
    public class DeleteGenreCommand{

        public int GenreId { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(x=>x.Id == GenreId);
            if(genre is null){
                throw new InvalidOperationException("Kitap türü bulunmadı");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }


    }
}