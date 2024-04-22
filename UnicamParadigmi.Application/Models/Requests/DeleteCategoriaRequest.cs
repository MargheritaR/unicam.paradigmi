using UnicamParadigmi.Application.Models.Dtos;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Models.Requests
{
    public class DeleteCategoriaRequest
    {
        public string NomeCategoria { get; set; }

        public Categoria ToEntity()
        {
            var categoria = new Categoria();
            categoria.NomeCategoria = NomeCategoria;
            return categoria;
        }
    }
}
