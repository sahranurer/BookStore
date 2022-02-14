using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

                context.Books.AddRange(new Book
                {
                    
                    Title = "Lean Startup",
                    GenreId = 1, //Personel Growth
                    PageCount = 300,
                    PublishDate = new DateTime(2001, 02, 12)

                },
               new Book
               {
                  
                   Title = "Herland",
                   GenreId = 2, //Science Fiction
                   PageCount = 250,
                   PublishDate = new DateTime(2010, 05, 20)

               },
              new Book
              {
                 
                  Title = "Done",
                  GenreId = 2, //Science Fiction
                  PageCount = 350,
                  PublishDate = new DateTime(2011, 05, 19)

              });

              context.SaveChanges();

            }

        }
    }
}
