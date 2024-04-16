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
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public CategoriaRepository(MyDbContext ctx) : base(ctx)
        {
           
        }
        public Categoria GetNomeCategoria(string id) 
        {
            return _ctx.Set<Categoria>().Include(c => c.Libri)
                .Where(x => x.NomeCategoria.Equals( id)).FirstOrDefault();
        }
    }
}
