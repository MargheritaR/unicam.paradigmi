using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Models.Context;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Test.Examples
{
    public class EntityFrameworkExample
    {

        public MyDbContext DbContext { get; set; }


        public EntityFrameworkExample()
        {
            DbContext = new MyDbContext();
        }

        public void RunExample()
        {
            var ctx = new MyDbContext();
            //var libri = ctx.Libri.ToList();
            // Filtro(ctx);
            // AggiungiLibro(ctx);
           // ModificaLibro(ctx);
            RimuoviLibro(ctx);
        }

        private void AggiungiLibro(MyDbContext ctx)
        {
            var nuovoLibro = new Libro();
            nuovoLibro.Nome = "L'Occhio del mondo";
            nuovoLibro.ISBN = "978-88-347-3834-4";
            nuovoLibro.Autore = "Robert Jordan";
            nuovoLibro.Categoria = "Fantasy";
            nuovoLibro.Editore = "Fanucci Editore";

            ctx.Libri.Add(nuovoLibro);

            ctx.SaveChanges();
            Console.WriteLine($"Aggiunto Libro con ISBN {nuovoLibro.ISBN} e nome {nuovoLibro.Nome}");
        }

        private void ModificaLibro(MyDbContext ctx)
        {
            var modLibro = new Libro();
            modLibro.ISBN = "978-88-347-3834-4";
            modLibro.Nome = "L'Occhio del mondo (Modificato)";
            var entry = ctx.Entry(modLibro);
            entry.Property(p => p.Nome).IsModified = true;

            ctx.SaveChanges();
        }

        private void RimuoviLibro(MyDbContext ctx)
        {
            var rimuovLibro = new Libro();
            rimuovLibro.ISBN = "978-88-347-3835-1";
            var entry = ctx.Entry(rimuovLibro);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            ctx.SaveChanges();
        }

        private void Filtro(MyDbContext ctx)
        {
            // Libri che iniziano con la Lettera L
            var libriConPSintassiFluida = ctx.Libri.Where(w => w.Nome.StartsWith("L"));

            foreach (var libro in libriConPSintassiFluida)
            {
                Console.WriteLine(libro);
            }
        }
    }
}