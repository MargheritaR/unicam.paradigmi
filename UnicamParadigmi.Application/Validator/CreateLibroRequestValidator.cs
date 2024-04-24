using FluentValidation;
using UnicamParadigmi.Application.Models.Requests;


namespace UnicamParadigmi.Application.Validator
{
    public class CreateLibroRequestValidator : AbstractValidator<CreateLibroRequest>
    {

        public CreateLibroRequestValidator()
        {

            RuleFor(l => l.Editore)
                .NotEmpty()
                .WithMessage("Il campo Editore non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Editore non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Il campo Editore deve essere lungo almeno 3 caratteri");

            RuleFor(l => l.Autore)
                .NotEmpty()
                .WithMessage("Il campo Autore non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Autore non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Il campo Autore deve essere lungo almeno 3 caratteri");

            RuleFor(l => l.Nome)
                .NotEmpty()
                .WithMessage("Il campo Nome non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Nome non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Il campo Nome deve essere lungo almeno 3 caratteri");

            RuleFor(l => l.Categoria)
                .NotEmpty()
                .WithMessage("Il campo Categoria non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Categoria non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Il campo Categoria deve essere lungo almeno 3 caratteri");

            RuleFor(l => l.DatadiPubblicazione)
                .NotEmpty().
                WithMessage("Il campo Data di Pubblicazione non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Categoria non può essere nullo");

            RuleFor(d => d.ISBN)
               .NotEmpty()
               .WithMessage("Il campo ISBN non può essere vuoto")
               .NotNull()
               .WithMessage("Il campo ISBN non può essere nullo")
               .MinimumLength(15)
               .WithMessage("Il campo ISBN deve essere lungo almeno 15 csaratteri");
        }
    }
}
