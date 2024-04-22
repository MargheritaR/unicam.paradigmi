using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

        public List<Libro> GetLibriNome(int from, int num, string? name, out int totalNum)
        {
            var query = _ctx.Libri.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(w => w.Nome.ToLower().Contains(name.ToLower()));
            }

            totalNum = query.Count();

            return query.OrderBy(o => o.Nome).Skip(from).Take(num).ToList();
        }

        public List<Libro> GetLibriAutore(int from, int num, string? autore, out int totalNum)
        {
            var query = _ctx.Libri.AsQueryable();
            if (!string.IsNullOrEmpty(autore))
            {
                query = query.Where(w => w.Autore.ToLower().Contains(autore.ToLower()));
            }

            totalNum = query.Count();

            return query.OrderBy(o => o.Autore).Skip(from).Take(num).ToList();
        }

        public List<Libro> GetLibriCategoria(int from, int num, string? categoria, out int totalNum)
        {
            var query = _ctx.Libri.AsQueryable();
            if (!string.IsNullOrEmpty(categoria))
            {
                query = query.Where(w => w.Categoria.ToLower().Contains(categoria.ToLower()));
            }

            totalNum = query.Count();

            return query.OrderBy(o => o.Categoria).Skip(from).Take(num).ToList();
        }


        public List<Libro> GetLibriDataDiPubblicazione(int from, int num, DateTime? datadiPubblicazione, out int totalNum)
        {
            var query = _ctx.Libri.AsQueryable();
            if (datadiPubblicazione.HasValue)
            {
                query = query.Where(w => w.DatadiPubblicazione.Equals(datadiPubblicazione));
            }

            totalNum = query.Count();

            return query.OrderBy(o => o.DatadiPubblicazione).Skip(from).Take(num).ToList();
        }

        public List<Categoria> ControlloCategoria(Libro libro)
        {
            var query = _ctx.Categorie.AsQueryable();
            query = query.Where(w => w.NomeCategoria.Equals(libro.Categoria));
            return query.ToList();
        }

    }
}
