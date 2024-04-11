using Microsoft.AspNetCore.Mvc;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Application.Models.Requeste;
using UnicamParadigmi.Application.Services;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        public LibroController(ILibroService libroService) 
        {
            _libroService = libroService;
        }
      
        
        [HttpGet]
        [Route("list")]
        public IEnumerable<Libro> GetLibri()
        {
            //return libri;
            return null;
        }
        
        [HttpGet]
        [Route("get/{isbn}")]
        public Libro GetLibro(string isbn)
        {
            // return libri.Where(w => w.ISBN == isbn).First();
            return null;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult NewLibro(CreateLibroRequest request)
        {
            var libro = request.ToEntity();
            _libroService.AddLibro(libro);
            return Ok();
        }
    }
}
