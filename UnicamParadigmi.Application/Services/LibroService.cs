using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Models.Entities;
using UnicamParadigmi.Models.Repositories;

namespace UnicamParadigmi.Application.Services
{
    public class LibroService : ILibroService
    {
        private readonly LibroRepository _libroRepository;

        public LibroService(LibroRepository libroRepository) 
        {
            _libroRepository = libroRepository;
        }

        public void AddLibro(Libro libro)
        {
            _libroRepository.Aggiungi(libro);
            _libroRepository.Salvataggio();
        }

        public void DeleteLibro(Libro libro)
        {
            _libroRepository.Rimuovi(libro);
            _libroRepository.Salvataggio();
        }

        public void EditLibro(Libro libro)
        {
            _libroRepository.Modifica(libro);
            _libroRepository.Salvataggio();
        }

        public List<Libro> GetLibri()
        {
            return new List<Libro>();
        }

        public List<Libro> GetLibri(int from, int num, string? name,out int totalNum)
        {
            return _libroRepository.GetLibri(from, num, name, out totalNum);
        }
    }
}
