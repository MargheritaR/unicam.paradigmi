using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Models.Entities;
using UnicamParadigmi.Models.Repositories;

namespace UnicamParadigmi.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;
        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public void AddCategoria(Categoria categoria)
        {
            _categoriaRepository.Aggiungi(categoria);
            _categoriaRepository.Salvataggio();
        }

        public void DeleteCategoria(Categoria categoria)
        {
            _categoriaRepository.Rimuovi(categoria);
            _categoriaRepository.Salvataggio();
        }
    }
}
