using FluentValidation;
using System.Text.RegularExpressions;
using UnicamParadigmi.Application.Extension;
using UnicamParadigmi.Application.Models.Requests;

namespace UnicamParadigmi.Application.Validator
{
    public class CreateLoginRequestValidator : AbstractValidator<CreateLoginRequest>
    {
        public CreateLoginRequestValidator()
        {
            RuleFor(r => r.Username)
                .NotEmpty()
                .WithMessage("Il campo è obbligatorio")
                .NotNull()
                .WithMessage("Il campo username non può essere nullo");

            RuleFor(p => p.Password).NotEmpty()
                .WithMessage("Il password è obbligatorio")
                .NotNull()
                .WithMessage("Il campo password non può essere nullo");

        }
        
    }
}
