using Microsoft.AspNetCore.Components.Forms;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Models.Requests
{
    public class CreateCategoriaRequest
    {
        public string NomeCategoria { get; set; }


        public Categoria ToEntity()
        {
            var categoria = new Categoria();
            categoria.NomeCategoria = NomeCategoria;
            return categoria;
        }
        public void Prova()
        {
            
        }
    }

}
