using FluentValidation;
using System.Text.RegularExpressions;
using UnicamParadigmi.Application.Extension;
using UnicamParadigmi.Application.Models.Requests;

namespace UnicamParadigmi.Application.Validator
{
    public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
    {
        public CreateTokenRequestValidator()
        {
            RuleFor(r => r.Username).NotEmpty()
                .WithMessage("Il campo è obbligatorio")
                .NotNull()
                .WithMessage("Il campo username non può essere nullo");

            RuleFor(p => p.Password).NotEmpty()
                .WithMessage("Il password è obbligatorio")
                .NotNull()
                .WithMessage("Il campo password non può essere nullo")
                .MinimumLength(6)
                .WithMessage("Il campo deve contenere almeno 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo,uno  minuscolo, un numero e un carattere speciale ");
                /*.Custom((value, context) =>
                {
                    var regEx = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$");
                    if (regEx.IsMatch(value) == false)
                    {
                        context.AddFailure("Il campo deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo,uno  minuscolo, un numero e un carattere speciale ");
                    }
                });*/
        }
    }
}
