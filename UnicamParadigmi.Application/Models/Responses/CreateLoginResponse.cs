namespace UnicamParadigmi.Application.Models.Responses
{
    public class CreateLoginResponse
    {
        public CreateLoginResponse(string token) 
        {
            Token = token;
        }
        public string Token { get; set; } = string.Empty;
        
    }
}
