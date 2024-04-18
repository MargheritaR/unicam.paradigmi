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
      /* public  Categoria GetByNome(Categoria categoria)
        {
            if (_ctx.Set<Categoria>().Include(c => c.Libri)
                .Where(x => x.NomeCategoria.Equals(categoria.NomeCategoria)).FirstOrDefault() == null)
            {
                return null;
            }
           /* return _ctx.Set<Categoria>().Include(c => c.Libri)
                .Where(x => x.NomeCategoria.Equals(categoria.NomeCategoria)).FirstOrDefault();
        }*/
    }
}
