using UnicamParadigmi.Application.Models.Dtos;

namespace UnicamParadigmi.Application.Models.Responses
{
    public class GetLibroResponse
    {
        public List<LibroDtos> Libri { get; set;} = new List<LibroDtos>();
        public int NumeroPagine { get; set; }
    }
}
