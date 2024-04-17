using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using UnicamParadigmi.Application.Models.Dtos;
using UnicamParadigmi.Application.Models.Requests;
using UnicamParadigmi.Models.Context;
using UnicamParadigmi.Models.Repositories;

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
