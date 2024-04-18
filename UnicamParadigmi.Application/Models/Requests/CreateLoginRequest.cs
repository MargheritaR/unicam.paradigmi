using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Application.Models.Requests
{
    public class CreateLoginRequest
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public Utente ToEntity()
        {
            var utente = new Utente();
            utente.Email = Username;
            utente.Password = Password;
            return utente;
        }
    }

}
