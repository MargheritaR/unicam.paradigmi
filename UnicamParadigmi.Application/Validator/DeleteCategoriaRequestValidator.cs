using FluentValidation;
using UnicamParadigmi.Application.Models.Requests;

namespace UnicamParadigmi.Application.Validator
{
    public class DeleteCategoriaRequestValidator : AbstractValidator<DeleteCategoriaRequest>
    {
        public DeleteCategoriaRequestValidator()
        {
            RuleFor(n => n.NomeCategoria)
                .NotEmpty()
                .WithMessage("Il campo Nome Categoria non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Nome Categoria non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Il campo Nome Categoria deve essere lungo almeno 3 caratteri");
            

        }
    }
}
