using FluentValidation;

namespace WebApi.Aplication.GenreOperations.Command.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(Command => Command.GenreId).GreaterThan(0);
        }
    }
}