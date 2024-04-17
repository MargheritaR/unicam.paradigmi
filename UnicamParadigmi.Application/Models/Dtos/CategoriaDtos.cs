using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Models.Dtos
{
    public class CategoriaDtos
    {
        public string NomeCategoria { get; set; } = string.Empty;

        public CategoriaDtos() { }

        public CategoriaDtos(Categoria categoria)
        {
            NomeCategoria = categoria.NomeCategoria;
        }
    }
}
