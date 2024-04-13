using FluentValidation;
using UnicamParadigmi.Application.Models.Requests;

namespace UnicamParadigmi.Application.Validator
{
    public class CreateLibroRequestValidator : AbstractValidator<CreateLibroRequest>
    {

        public CreateLibroRequestValidator()
        {

            RuleFor(l => l.Editore)
                .NotNull()
                .WithMessage("Il campo Editore non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Editore non può essere vuoto")
                .MinimumLength(3)
                .WithMessage("Il campo Editore deve essere lungo almeno 3 caratteri");

            RuleFor(l => l.Autore)
                .NotNull()
                .WithMessage("Il campo Autore non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Autore non può essere vuoto")
                .MinimumLength(3)
                .WithMessage("Il campo Autore deve essere lungo almeno 3 caratteri");

            RuleFor(l => l.Nome)
                .NotNull()
                .WithMessage("Il campo Nome non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Nome non può essere vuoto")
                .MinimumLength(3)
                .WithMessage("Il campo Nome deve essere lungo almeno 3 caratteri");

            RuleFor(l => l.Categoria)
                .NotNull()
                .WithMessage("Il campo Categoria non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Categoria non può essere vuoto")
                .MinimumLength(3)
                .WithMessage("Il campo Categoria deve essere lungo almeno 3 caratteri");

            RuleFor(l => l.DatadiPubblicazione)
                .NotNull()
                .WithMessage("Il campo Data di Pubblicazione non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Categoria non può essere vuoto");


            RuleFor(l => l.ISBN).NotNull();
        }
    }
}
