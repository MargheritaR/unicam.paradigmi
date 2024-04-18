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
            /*if(_categoriaRepository.GetByNome(categoria) != null) 
            {
                return false;
            }*/
            _categoriaRepository.Aggiungi(categoria);
            _categoriaRepository.Salvataggio();
            

        }

        public bool DeleteCategoria(string nome)
        {
            /* Categoria categoria = _categoriaRepository.GetByNome(nome);
             if(categoria != null && !categoria.Libri.Any()) 
             {
                 _categoriaRepository.Rimuovi(categoria);
                 _categoriaRepository.Salvataggio();
                 return true;
             }
             return false;*/
            return false;
        }
    }
}
