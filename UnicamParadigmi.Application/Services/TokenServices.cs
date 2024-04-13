using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Application.Models.Requests;

namespace UnicamParadigmi.Application.Services
{
    public class TokenServices : ITokenService
    {
        public string CreateToken(CreateTokenRequest request)
        {
            var issuer = "https://paradigmi.unicam.it";

            string key = "UnicamParadigmi.Chiave1234567890123";

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Nome", "Federico"));
            claims.Add(new Claim("Cognome", "Paoloni"));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var crediatials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(issuer, null, claims, expires : DateTime.Now.AddMinutes(30)
                ,signingCredentials : crediatials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token; 
        }

    }
}
