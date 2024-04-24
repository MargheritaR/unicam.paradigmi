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

            if (_utenteService.CheckEmail(utente) == true)
            {
                throw new Exception("La email è già stata utilizzata ");
            }

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

            if (_utenteService.CheckUtente(utente) == false) {
                throw new Exception("La email o la password non sono corretti o l'account è inesistente");
            }

            string token = _utenteService.CreateToken(utente);

            return Ok(ResponseFactory.WithSuccess(new CreateLoginResponse(token)));
        }
    }
}
