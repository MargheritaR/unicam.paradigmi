﻿using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Models.Requeste
{
    public class CreateLibroRequest
    {
        public string ISBN { get; set; }
        public string Nome { get; set; } = string.Empty;

        public string Autore { get; set; } = string.Empty;

        public string Editore { get; set; } = string.Empty;
        public string Categoria { get; set; }

        public DateTime DatadiPubblicazione { get; set; }

        public Libro ToEntity()
        {
            var libro = new Libro();
            libro.ISBN = ISBN;
            libro.Nome = Nome;
            libro.Autore = Autore;
            libro.Editore = Editore;
            libro.Categoria = Categoria;
            libro.DatadiPubblicazione = DatadiPubblicazione;
            return libro;
        }
    }
}
