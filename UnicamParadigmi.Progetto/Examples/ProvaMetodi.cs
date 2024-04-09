using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Models.Context;
using UnicamParadigmi.Models.Repositories;

namespace UnicamParadigmi.Test.Examples
{
    public class ProvaMetodi
    {

        public MyDbContext DbContext { get; set; }

        public ProvaMetodi()
        {
            DbContext = new MyDbContext();
        }

        public void RunExample()
        {
            var prova = new LibroRepository(DbContext);
            /*
            prova.GetLibroPerNome("L'Occhio del mondo");
            var data = DateTime.Parse("2015-07-10");
            GetLibroPerDataDiPubblicazione(data);
            GetLibroCategoria("Giallo");
            GetLibroAutore("Robert Jordan");
            */
        }

    }
}
