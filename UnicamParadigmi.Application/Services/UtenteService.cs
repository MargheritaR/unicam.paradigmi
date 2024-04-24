using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Application.Options;
using UnicamParadigmi.Models.Entities;
using UnicamParadigmi.Models.Repositories;

namespace UnicamParadigmi.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;
        private readonly JwtAuthenticationOption _jwtAutOptions;

        public UtenteService(UtenteRepository utenteRepository, IOptions<JwtAuthenticationOption> jwtAutOptions)
        {
            _utenteRepository = utenteRepository;
            _jwtAutOptions = jwtAutOptions.Value;
        }

        public void AddUtente(Utente utente)
        {
            _utenteRepository.Aggiungi(utente);
            _utenteRepository.Salvataggio();
        }

        public string CreateToken(Utente utente)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, utente.Email),
                new Claim("Id", utente.IdUtente.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAutOptions.Key));
            var crediatials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(_jwtAutOptions.Issuer, null, claims, expires: DateTime.Now.AddMinutes(30)
                , signingCredentials: crediatials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

        public bool CheckUtente(Utente utente)
        {
            if (_utenteRepository.ControlloUtente(utente).IsNullOrEmpty())
            {
                return false;
            }
            return true;
        }

        public bool CheckEmail(Utente utente)
        {
            if (_utenteRepository.ControlloEmail(utente).IsNullOrEmpty())
            {
                return false;
            }
            return true;
        }
    }
}
