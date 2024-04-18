using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Application.Factories;
using UnicamParadigmi.Application.Models.Requests;
using UnicamParadigmi.Application.Models.Responses;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult NuovoUtente(CreateUtenteRequest request)
        {
            var utente = request.ToEntity();
            _utenteService.AddUtente(utente);

            var response = new CreateUtenteResponse();
            response.Utente = new Application.Models.Dtos.UtenteDtos(utente);
            return Ok(ResponseFactory.WithSuccess(response));
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(CreateLoginRequest request)
        {
            var utente = request.ToEntity();
           string token = _utenteService.CreateToken(utente);

            return Ok(ResponseFactory.WithSuccess(new CreateLoginResponse(token)));
        }
    }
}
