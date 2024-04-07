using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Models.Context;

namespace UnicamParadigmi.Models.Repositories
{
    public  abstract class GenericRepository<T> where T: class 
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Aggiungi(T entity) 
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        }
        
        public void Modifica(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Rimuovi(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public T Get(object id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Salvataggio()
        {
            _ctx.SaveChanges();
        }
    }
}
