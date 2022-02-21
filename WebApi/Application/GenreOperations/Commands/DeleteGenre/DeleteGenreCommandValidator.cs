using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre.DeleteGenreCommand{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>{

        public DeleteGenreCommandValidator(){
            RuleFor(x=>x.GenreId).GreaterThan(0);
        }


    }
}