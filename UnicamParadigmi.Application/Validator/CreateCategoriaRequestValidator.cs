using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using UnicamParadigmi.Application.Models.Requests;
using UnicamParadigmi.Models.Context;
using UnicamParadigmi.Models.Repositories;

namespace UnicamParadigmi.Application.Validator
{
    public class CreateCategoriaRequestValidator : AbstractValidator<CreateCategoriaRequest>
    {
        private readonly CategoriaRepository _categoriaRepository = new CategoriaRepository(new MyDbContext());
        public CreateCategoriaRequestValidator()
        {
            RuleFor(n => n.NomeCategoria)
                .NotNull()
                .WithMessage("Il campo Nome Categoria non può essere nullo")
                .NotEmpty()
                .WithMessage("Il campo Nome Categoria non può essere vuoto")
                .MinimumLength(3)
                .WithMessage("Il campo Nome Categoria deve essere lungo almeno 3 caratteri");

            RuleFor(r => r)
                .Custom(c =>
                {

                    _categoriaRepository.GetNomeCategoria(c.NomeCategoria);
                })
                .WithMessage("Il campo Nome Categoria è già esistente");
        }
    }
}
