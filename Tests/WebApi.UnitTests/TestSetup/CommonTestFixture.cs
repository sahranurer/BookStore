using WebApi.DbOperations;
using AutoMapper;


namespace TestSetup
{
    public class CommonTestFixture{
        public BookStoreDbContext Context {get;set;}
        public IMapper Mapper {get;set;}
        public CommonTestFixture(){
            var options = new DBContextOptionsBuild<BookStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDB").options;
            Context = new BookStoreDbContext(options);
            Context.Database.EnsureCreated();
        }
    }
}