using FluentValidation;
using WebApi.Aplication.GenreOperations.Command.UpdateGenre;

namespace WebApi.Aplication.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandValidator :  AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(1).When(x => x.Model.Name.Trim() != string.Empty);
        }
    }
}