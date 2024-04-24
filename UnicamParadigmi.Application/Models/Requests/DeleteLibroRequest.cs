using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Models.Requests
{
    public class DeleteLibroRequest
    {
        public string ISBN { get; set; }

        public Libro ToEntity()
        {
            var libro = new Libro();
            libro.ISBN = ISBN;
            return libro;
        }
    }
}
