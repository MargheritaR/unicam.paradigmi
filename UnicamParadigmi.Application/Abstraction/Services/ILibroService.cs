using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Abstraction.Services
{
    public interface ILibroService
    {
        List<Libro> GetLibri();
        void AddLibro(Libro libro);
    }
}
