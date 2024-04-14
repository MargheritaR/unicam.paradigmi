using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnicamParadigmi.Application.Abstraction.Services;
using UnicamParadigmi.Application.Models.Requests;
using UnicamParadigmi.Application.Options;

namespace UnicamParadigmi.Application.Services
{
    public class TokenServices : ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAutOptions;
        public TokenServices(IOptions<JwtAuthenticationOption> jwtAutOptions) 
        {
            _jwtAutOptions = jwtAutOptions.Value;
        }
        public string CreateToken(CreateTokenRequest request)
        {

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Nome", "Federico"));
            claims.Add(new Claim("Cognome", "Paoloni"));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAutOptions.Key));
            var crediatials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(_jwtAutOptions.Issuer, null, claims, expires : DateTime.Now.AddMinutes(30)
                ,signingCredentials : crediatials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token; 
        }

    }
}
