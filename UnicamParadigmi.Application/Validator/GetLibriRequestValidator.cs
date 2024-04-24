using FluentValidation;
using UnicamParadigmi.Application.Models.Requests;

namespace UnicamParadigmi.Application.Validator
{
    public class GetLibriRequestValidator : AbstractValidator<GetLibriRequest>
    {
        public GetLibriRequestValidator()
        {
            RuleFor(g => g.PageSize)
                .NotEmpty()
                .WithMessage("Il campo PageSize non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo PageSize non può essere nullo");
                

            RuleFor(g => g.Cerca)
                .NotEmpty()
                .WithMessage("Il campo Name non può essere vuoto")
                .NotNull()
                .WithMessage("Il campo Name non può essere nullo");
        }
    }
}
