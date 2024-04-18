using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Application.Factories;
using UnicamParadigmi.Application.Models.Requests;
using UnicamParadigmi.Application.Models.Responses;
using UnicamParadigmi.Application.Services;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        public LibroController(ILibroService libroService) 
        {
            _libroService = libroService;
        }
      
        // Ricerca per nome con Paginazione
        [HttpPost]
        [Route("list/nome")]
        public IActionResult GetLibriNome(GetLibriRequest request)
        {
            // Validare la paginazione
            int totalNum = 0;
            var libri = _libroService.GetLibriNome(request.Page * request.PageSize, request.PageSize, request.Name, out totalNum);
            var response = new GetLibroResponse();  
            var pageFounded = (totalNum / (decimal) request.PageSize);
            response.NumeroPagine = (int) Math.Ceiling(pageFounded);
            response.Libri = libri.Select(s => new Application.Models.Dtos.LibroDtos(s)).ToList();
            return Ok(ResponseFactory.WithSuccess(response));
        }

        // Ricerca per autore con Paginazione
        [HttpPost]
        [Route("list/autore")]
        public IActionResult GetLibriAutore(GetLibriRequest request)
        {
            // Validare la paginazione
            int totalNum = 0;
            var libri = _libroService.GetLibriAutore(request.Page * request.PageSize, request.PageSize, request.Name, out totalNum);
            var response = new GetLibroResponse();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.NumeroPagine = (int)Math.Ceiling(pageFounded);
            response.Libri = libri.Select(s => new Application.Models.Dtos.LibroDtos(s)).ToList();
            return Ok(ResponseFactory.WithSuccess(response));
        }

        // Ricerca per categoria con Paginazione
        [HttpPost]
        [Route("list/categoria")]
        public IActionResult GetLibriCategoria(GetLibriRequest request)
        {
            // Validare la paginazione
            int totalNum = 0;
            var libri = _libroService.GetLibriCategoria(request.Page * request.PageSize, request.PageSize, request.Name, out totalNum);
            var response = new GetLibroResponse();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.NumeroPagine = (int)Math.Ceiling(pageFounded);
            response.Libri = libri.Select(s => new Application.Models.Dtos.LibroDtos(s)).ToList();
            return Ok(ResponseFactory.WithSuccess(response));
        }

        // Ricerca per Data di Pubblicazione con Paginazione
        [HttpPost]
        [Route("list/datadiPubblicazione")]
        public IActionResult GetLibriDataDiPubblicazione(GetLibriRequest request)
        {
            // Validare la paginazione
            int totalNum = 0;
            var libri = _libroService.GetLibriDatadiPubblicazione(request.Page * request.PageSize, request.PageSize, request.Name, out totalNum);
            var response = new GetLibroResponse();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.NumeroPagine = (int)Math.Ceiling(pageFounded);
            response.Libri = libri.Select(s => new Application.Models.Dtos.LibroDtos(s)).ToList();
            return Ok(ResponseFactory.WithSuccess(response));
        }

        // Aggiungere un nuovo libro
        [HttpPost]
        [Route("new")]
        public IActionResult AggiungiLibro(CreateLibroRequest request)
        {
            var libro = request.ToEntity();
            _libroService.AddLibro(libro);

            var response = new CreateLibroResponse();
            response.Libro = new Application.Models.Dtos.LibroDtos(libro);
            return Ok(ResponseFactory.WithSuccess(response));
        }


        // Rimozione di un libro
        [HttpPost]
        [Route("delete")]
        public IActionResult RimuoviLibro(DeleteLibroRequest request)
        {
            var libro = request.ToEntity();
            _libroService.DeleteLibro(libro);

            var response = new DeleteLibroResponse();
            response.Libro = new Application.Models.Dtos.LibroDtos(libro);
            return Ok(ResponseFactory.WithSuccess(response));
        }

        // Modifica di un libro
        [HttpPost]
        [Route("edit")]
        public IActionResult ModificaLibro(EditLibroRequest request)
        {
            var libro = request.ToEntity();
            _libroService.EditLibro(libro);

            var response = new DeleteLibroResponse();
            response.Libro = new Application.Models.Dtos.LibroDtos(libro);
            return Ok(ResponseFactory.WithSuccess(response));
        }


    }
}
