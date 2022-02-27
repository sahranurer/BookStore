using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations{
    public class GetAuthorsQuery{
        private readonly IBookStoreDbContext _context;

        private  readonly IMapper _mapper;

        public GetAuthorsQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       public List<AuthorViewModel> Handle(){
           var authorlist = _context.Authors.OrderBy(x=>x.Id).ToList();
           List<AuthorViewModel> vm = _mapper.Map<List<AuthorViewModel>>(authorlist);
           return vm;
       }

    }

    public class AuthorViewModel{
        public string Name { get; set; }

        public string Surname { get; set; }

        public string BirthDate { get; set; }

    }
}