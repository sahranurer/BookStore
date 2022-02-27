using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands
{
    public class UpdateAuthorCommand
    {
        private readonly IBookStoreDbContext _context;

        public int AuthorId { get; set; }

        public UpdateAuthorModel Model { get; set; }

        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

          public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Güncellenecek yazar bulunamadı");
            }

            author.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
            author.Surname = string.IsNullOrEmpty(Model.Surname.Trim()) ? author.Surname : Model.Surname;

            _context.SaveChanges();
        }

    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

       

    }


}