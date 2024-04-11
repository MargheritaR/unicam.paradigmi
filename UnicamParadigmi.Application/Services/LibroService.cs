using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Services
{
    public class LibroService : ILibroService
    {
        public List<Libro> GetLibri()
        {
            return new List<Libro>();
        }
    }
}
