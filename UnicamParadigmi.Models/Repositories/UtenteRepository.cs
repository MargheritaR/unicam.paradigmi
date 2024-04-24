using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Models.Context;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Models.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(MyDbContext ctx) : base(ctx) { }

        public List<Utente> ControlloUtente(Utente utente)
        {
            var query = _ctx.Utenti.AsQueryable();
            query = query.Where(w => w.Email.Equals(utente.Email) && w.Password.Equals(utente.Password));
            return query.ToList();
        }

        public List<Utente> ControlloEmail(Utente utente)
        {
            var query = _ctx.Utenti.AsQueryable();
            query = query.Where(w => w.Email.Equals(utente.Email));
            return query.ToList();
        }
    }
}
