using UnicamParadigmi.Application.Models.Dtos;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Models.Responses
{
    public class DeleteCategoriaResponse
    {
        public CategoriaDtos Categoria { get; set; } = null!;
    }
}
