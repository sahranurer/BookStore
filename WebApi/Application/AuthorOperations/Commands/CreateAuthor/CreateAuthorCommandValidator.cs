using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.Surname).NotEmpty();
            RuleFor(command => command.Model.BirthDate).NotEmpty();

        }
    }
}