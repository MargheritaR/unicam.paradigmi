using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicamParadigmi.Models.Entities
{
    public class Utente
    {
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public int IdUtente { get; set;}

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
