using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Abstraction.Services
{
    public interface ILibroService
    {
        List<Libro> GetLibri();

        List<Libro> GetLibriNome(int from, int num, string? name, out int totalNum);

        List<Libro> GetLibriAutore(int from, int num, string? autore, out int totalNum);

        List<Libro> GetLibriCategoria(int from, int num, string? categoria, out int totalNum);

        List<Libro> GetLibriDatadiPubblicazione(int from, int num, string? datadiPubblicazione, out int totalNum);
        

        void AddLibro(Libro libro);

        void DeleteLibro(Libro libro);

        void EditLibro(Libro libro);

        bool ValidateCategoria(Libro libro);

    }
}
