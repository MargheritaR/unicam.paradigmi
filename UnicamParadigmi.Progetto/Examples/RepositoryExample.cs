using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Models.Context;
using UnicamParadigmi.Models.Repositories;

namespace UnicamParadigmi.Test.Examples
{
    public class RepositoryExample 
    {
        public void RunExample()
        {
            var ctx = new MyDbContext();
            var libroRepo = new LibroRepository(ctx);

            var libro = libroRepo.Get("978-88-347-3836-8");
            libro.Categoria = "Fantasy";
            libroRepo.Modifica(libro);
            libroRepo.Salvataggio();

        }
    }
}
