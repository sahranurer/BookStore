using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations

{
    public class BookStoreDbContext : DbContext,IBookStoreDbContext{
    public BookStoreDbContext()
        {

        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
            // DbContext'in kullanacağı ayarlar, varsa Context üretim anında kullanılacak özel ayarlar belirtilir
            // Initialize a new instance of Context using the specified options
        }      
  

    public DbSet<Book> Books {get;set;}
    public DbSet<Genre> Genres {get;set;}

    public DbSet<Author> Authors { get; set; }
   public override int SaveChanges(){
         return base.SaveChanges();       
   }
}
}