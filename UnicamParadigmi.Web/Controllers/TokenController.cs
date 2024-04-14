using Microsoft.AspNetCore.Mvc;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Application.Factories;
using UnicamParadigmi.Application.Models.Requests;
using UnicamParadigmi.Application.Models.Responses;

namespace UnicamParadigmi.Web.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenSerivice)
        {
            _tokenService = tokenSerivice;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateTokenRequest request)
        {
            string token = _tokenService.CreateToken(request);
            return Ok(ResponseFactory.WithSuccess( new CreateTokenResponse (token)));
        }
    }
}
