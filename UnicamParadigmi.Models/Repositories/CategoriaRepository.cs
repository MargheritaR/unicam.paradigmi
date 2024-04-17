using Castle.Core.Internal;
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
        public MyDbContext Context { get; set; }

        public CategoriaRepository(MyDbContext ctx) : base(ctx)
        {
           
        }
        /*
        public bool ControlloCategoria(string? name)
        {
            var query = _ctx.Categorie.AsQueryable();
            query = query.Where(l => l.NomeCategoria.Equals(name));
            if (!(query.IsNullOrEmpty()))
            {
                return false;
            }
            return true;
        }
        */
    }
}
