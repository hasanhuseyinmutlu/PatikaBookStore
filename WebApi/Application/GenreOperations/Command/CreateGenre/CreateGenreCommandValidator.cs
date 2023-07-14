using FluentValidation;

namespace WebApi.Aplication.GenreOperations.Command.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(Command => Command.Model.Name).NotEmpty().MinimumLength(1);
        }
    }
}