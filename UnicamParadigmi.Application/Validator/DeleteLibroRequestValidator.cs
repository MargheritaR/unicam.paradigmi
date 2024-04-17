using FluentValidation;
using UnicamParadigmi.Application.Models.Requests;

namespace UnicamParadigmi.Application.Validator
{
    public class DeleteLibroRequestValidator : AbstractValidator<DeleteLibroRequest>
    {
        public DeleteLibroRequestValidator()
        {
            RuleFor(d => d.ISBN)
                .NotEmpty()
                .WithMessage("Il campo ISBN non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo ISBN non può essere nullo")
                .MinimumLength(15)
                .WithMessage("Il campo ISBN deve essere lungo almeno 15 caratteri");
        }
    }
}
