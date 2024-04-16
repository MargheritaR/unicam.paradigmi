using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Application.Factories;
using UnicamParadigmi.Application.Models.Requests;
using UnicamParadigmi.Application.Models.Responses;
using UnicamParadigmi.Application.Services;

namespace UnicamParadigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // Aggiungere una nuova categoria
        [HttpPost]
        [Route("new")]
        public IActionResult AggiungiCategoria(CreateCategoriaRequest request)
        {
            var categoria = request.ToEntity();
            _categoriaService.AddCategoria(categoria);

            var response = new CreateCategoriaResponse();
            response.Categoria = new Application.Models.Dtos.CategoriaDtos(categoria);
            return Ok(ResponseFactory.WithSuccess(response));
        }

        // Rimozione di una categoria
        [HttpPost]
        [Route("delete")]
        public IActionResult RimuoviLibro(DeleteCategoriaRequest request)
        {
            var categoria = request.ToEntity();
            _categoriaService.DeleteCategoria(categoria);

            var response = new DeleteCategoriaResponse();
            response.Categoria = new Application.Models.Dtos.CategoriaDtos(categoria);
            return Ok(ResponseFactory.WithSuccess(response));
        }
    }
}
