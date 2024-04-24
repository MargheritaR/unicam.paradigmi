using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Application.Factories;
using UnicamParadigmi.Application.Models.Requests;
using UnicamParadigmi.Application.Models.Responses;

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

            if (_categoriaService.ValidateCategoria(categoria) == false)
            {
                throw new Exception("La categoria inserita è già esistente");
            }

            _categoriaService.AddCategoria(categoria);

            var response = new CreateCategoriaResponse();
            response.Categoria = new Application.Models.Dtos.CategoriaDtos(categoria);
            return Ok(ResponseFactory.WithSuccess(response));
        }

        // Rimozione di una categoria
        [HttpPost]
        [Route("delete")]
        public IActionResult RimuoviCategoria(DeleteCategoriaRequest request)
        {
            var categoria = request.ToEntity();

            if (_categoriaService.ValidateCategoria(categoria) == true)
            {
                throw new Exception("La categoria inserita non è esistente");
            }
            if (_categoriaService.ValidateEliminazione(categoria) == false)
            {
                throw new Exception("Ci sono dei libri legati a questa categoria");
            }

            _categoriaService.DeleteCategoria(categoria);

            var response = new DeleteCategoriaResponse();
            response.Categoria = new Application.Models.Dtos.CategoriaDtos(categoria);
            return Ok(ResponseFactory.WithSuccess(response));
        }
    }
}
