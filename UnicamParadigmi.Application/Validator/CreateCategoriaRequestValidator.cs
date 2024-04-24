using FluentValidation;
using UnicamParadigmi.Application.Models.Requests;

namespace UnicamParadigmi.Application.Validator
{
    public class CreateCategoriaRequestValidator : AbstractValidator<CreateCategoriaRequest>
    {
        public CreateCategoriaRequestValidator()
        {
            RuleFor(n => n.NomeCategoria)
                .NotNull()
                .WithMessage("Il campo Nome Categoria non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Nome Categoria non può essere vuoto")
                .MinimumLength(3)
                .WithMessage("Il campo Nome Categoria deve essere lungo almeno 3 caratteri");
        }
        
    }
}
