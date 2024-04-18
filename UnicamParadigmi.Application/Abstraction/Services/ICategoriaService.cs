using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Abstraction.Services
{
    public interface ICategoriaService
    {
        void AddCategoria(Categoria categoria);

        bool DeleteCategoria(string nome);
    }
}
