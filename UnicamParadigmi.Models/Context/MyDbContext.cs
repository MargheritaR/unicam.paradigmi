using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Models.Context
{

    public class MyDbContext : DbContext
    {
        public DbSet<Libro> Libri { get; set; }

        public DbSet<Utente> Utenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=localhost; Initial catalog=Paradigmi; User Id=AdParadigmi; Password=AdParadigmi; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

}
