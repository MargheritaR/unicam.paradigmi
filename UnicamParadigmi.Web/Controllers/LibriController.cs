using Microsoft.AspNetCore.Mvc;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LibroController : ControllerBase
    {
        List<Libro> libri = new List<Libro>();

        public LibroController()
        {
            libri.Add(new Libro()
            {
                ISBN = "978-88-350-4040-2",
                Nome = "Mare Gherita",
                Autore = "Daniele Il Rosso",
                DatadiPubblicazione = DateTime.Parse("10-03-2000"),
                Editore = "Camerino Editor"
            });
            libri.Add(new Libro()
            {
                ISBN = "978-88-400-6070-2",
                Nome = "Fracito",
                Autore = "Dome",
                DatadiPubblicazione = DateTime.Parse("23-10-2006"),
                Editore = "Camerino Editor"
            });
        }
        
        [HttpGet]
        [Route("list")]
        public IEnumerable<Libro> GetLibri()
        {
            return libri;
        }
        
        [HttpGet]
        [Route("get/{isbn}")]
        public Libro GetLibro(string isbn)
        {
            return libri.Where(w => w.ISBN == isbn).First();
        }
    }
}
