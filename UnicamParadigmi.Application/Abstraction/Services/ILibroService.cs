using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Abstraction.Services
{
    public interface ILibroService
    {
        List<Libro> GetLibri();

        List<Libro> GetLibri(int from, int num, string? name, out int totalNum);

        void AddLibro(Libro libro);

        void DeleteLibro(Libro libro);

        void EditLibro(Libro libro);
    }
}
