using Microsoft.IdentityModel.Tokens;
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

        public List<Libro> GetLibriNome(int from, int num, string? name,out int totalNum)
        {
            return _libroRepository.GetLibriNome(from, num, name, out totalNum);
        }

        public List<Libro> GetLibriAutore(int from, int num, string? autore, out int totalNum)
        {
            return _libroRepository.GetLibriAutore(from, num, autore, out totalNum);
        }
        public List<Libro> GetLibriCategoria(int from, int num, string? categoria, out int totalNum)
        {
            return _libroRepository.GetLibriCategoria(from, num, categoria, out totalNum);
        }

        public List<Libro> GetLibriDatadiPubblicazione(int from, int num, string? datadiPubblicazione, out int totalNum)
        {
            return _libroRepository.GetLibriDataDiPubblicazione(from, num, DateTime.Parse(datadiPubblicazione), out totalNum);
        }

        public bool ValidateCategoria(Libro libro)
        {
            if (_libroRepository.ControlloCategoria(libro).IsNullOrEmpty())
            {
                return false;
            }
            return true;
        }

    }
}
