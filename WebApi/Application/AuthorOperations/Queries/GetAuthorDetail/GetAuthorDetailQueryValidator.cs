using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>{
       public GetAuthorDetailQueryValidator(){
           //RuleFor(query=>query.AuthorId).NotEmpty.GreaterThan(0);
       }
    }
}