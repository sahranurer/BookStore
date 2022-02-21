using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenresDetailQuery{
    public class GetGenresDetailQueryValidator : AbstractValidator<GetGenresDetailQuery>{

        public GetGenresDetailQueryValidator(){
            RuleFor(x=>x.GenreId).GreaterThan(0);
        }
        

    }
}
