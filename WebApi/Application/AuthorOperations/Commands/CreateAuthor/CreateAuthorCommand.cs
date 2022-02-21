using System;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands{
    public  class CreateAuthorCommand{
          private readonly BookStoreDbContext _context;
          private readonly IMapper _mapper;   

          public CreateAuthorModel Model { get; set; }

        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       public void Handle(){
           var author = _context.Authors.SingleOrDefault(x=>x.Name == Model.Name);
           if(author is not null)
             throw new InvalidOperationException("Author zaten mevcut");

           author = _mapper.Map<Author>(Model);

           _context.Authors.Add(author);
           _context.SaveChanges();

       }


    }


public class CreateAuthorModel{
    
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

}

}