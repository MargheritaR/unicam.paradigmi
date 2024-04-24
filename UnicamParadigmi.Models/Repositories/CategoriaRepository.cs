using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Models.Context;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Models.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public MyDbContext Context { get; set; }

        public CategoriaRepository(MyDbContext ctx) : base(ctx)
        {
           
        }
      public List<Categoria> ControlloCategoria(Categoria categoria)
        {
            var query = _ctx.Categorie.AsQueryable();
            query = query.Where(w => w.NomeCategoria.Equals(categoria.NomeCategoria));
            return query.ToList();
        }

        public List<Libro> ControlloEliminazione(Categoria categoria)
        {
            var query = _ctx.Libri.AsQueryable();
            query = query.Where(e => e.Categoria.Equals(categoria.NomeCategoria));
            return query.ToList();
        }
    }
}
