﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicamParadigmi.Models.Entities
{
    public class Libro
    {
        public string ISBN { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Autore { get; set; } = string.Empty;

        public string Editore { get; set; } = string.Empty;

        public string Categoria { get; set; }
        
        public DateTime DatadiPubblicazione { get; set; }

        public Categoria CatAppartenente { get; set; }

    }
}
