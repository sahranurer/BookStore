using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommandValidator{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>{

        public CreateGenreCommandValidator(){
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(4);
        }
        

    }
}
