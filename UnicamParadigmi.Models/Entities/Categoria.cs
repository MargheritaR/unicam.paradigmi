using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicamParadigmi.Models.Entities
{
    public class Categoria
    {
        public string NomeCategoria { get; set; } = string.Empty;

        public ICollection<Libro> Libri { get; set; }

    }
}
