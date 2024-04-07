using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Models.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libri");
            builder.HasKey(k => k.ISBN);
            builder.HasOne(x => x.CatAppartenente).WithMany(x => x.Libri)
                .HasForeignKey(x => x.Categoria);
        }
    }
}
