using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
                      serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {


                if (context.Books.Any())
                {
                    return;
                }

                
                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Ahmet",
                        Surname = "Sezgin",
                        BirthDate = new DateTime(2000,3,21)
                    },
                    new Author
                    {
                        Name = "Osman",
                        Surname = "Sezgin",
                        BirthDate = new DateTime(2000,4,25)
                    },
                    new Author
                    {
                        Name = "Sezgin",
                        Surname = "Sezgin",
                        BirthDate = new DateTime(2000,6,11)
                    }
                );


                context.Genres.AddRange(new Genre{
                    Name = "Personel Growth"
                },
                new Genre{
                    Name = "Science Fiction"
                },
                new Genre{
                    Name = "Romance"
                }
                );

               
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Lean Startup",
                        GenreId = 1,
                        AuthorId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        Title = "Herland",
                        GenreId = 2,
                        AuthorId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        Title = "Dune",
                        GenreId = 2,
                        AuthorId = 3,
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 21)
                    }
                );
              context.SaveChanges();

            }

        }
    }
}
