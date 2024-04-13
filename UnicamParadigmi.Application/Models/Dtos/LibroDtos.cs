using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Models.Dtos
{
    public class LibroDtos
    {
        public string id { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;

        public string Editore { get; set; } = string.Empty;

        public string Autore { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public DateTime DatadiPubblicazione { get; set; }

        public LibroDtos() { }

        public LibroDtos(Libro libro)
        {
            id = libro.ISBN;
            Nome = libro.Nome;
            Editore = libro.Editore;
            Autore = libro.Autore;
            Categoria = libro.Categoria;
            DatadiPubblicazione = libro.DatadiPubblicazione;
        }

    }
}
