using FluentValidation;
using UnicamParadigmi.Application.Extension;
using UnicamParadigmi.Application.Models.Requests;

namespace UnicamParadigmi.Application.Validator
{
    public class CreateUtenteRequestValidator : AbstractValidator<CreateUtenteRequest>
    {
        public CreateUtenteRequestValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("Il campo Nome non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Nome non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Il campo Nome deve essere lungo almeno 3 caratteri"); ;

            RuleFor(u => u.Cognome)
                .NotEmpty()
                .WithMessage("Il campo Cognome non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Cognome non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Il campo Cognome deve essere lungo almeno 3 caratteri");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Il campo Email non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Email non può essere nullo")
                .MinimumLength(7)
                .WithMessage("Il campo Email deve essere lungo almeno 7 caratteri");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Il campo Password non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Password non può essere nullo")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo Password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo,uno minuscolo, " +
                "un numero e un carattere speciale ");
        }
    }
}
