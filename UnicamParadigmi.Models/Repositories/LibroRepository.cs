using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Models.Context;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Models.Repositories
{
    public class LibroRepository : GenericRepository<Libro>
    {
        public MyDbContext Context { get; set; }

        public LibroRepository(MyDbContext ctx) : base(ctx)
        {
            
        }

        public List<Libro> GetLibroPerNome(string nome)
        {
            var libro = Context.Libri.Where(l => l.Nome == nome).ToList();
            return libro;
        }
        public List<Libro> GetLibroPerDataDiPubblicazione(DateTime data)
        {
            var libro = Context.Libri.Where(l => l.DatadiPubblicazione == data).ToList();
            return libro;
        }

        public List<Libro> GetLibroCategoria(string categoria)
        {
            var libro = Context.Libri.Where(l => l.Categoria == categoria).ToList();
            return libro;
        }

        public List<Libro> GetLibroAutore(string autore)
        {
            var libro = Context.Libri.Where(l => l.Autore == autore).ToList();
            return libro;
        }
    }
}
