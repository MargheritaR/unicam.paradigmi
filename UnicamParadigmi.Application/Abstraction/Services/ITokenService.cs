using UnicamParadigmi.Application.Models.Requests;

namespace UnicamParadigmi.Application.Abstraction.Services
{
    public interface ITokenService
    {
        string CreateToken(CreateLoginRequest request);
    }
}
