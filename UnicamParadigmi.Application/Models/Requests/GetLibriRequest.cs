namespace UnicamParadigmi.Application.Models.Requests
{
    public class GetLibriRequest
    {
        public int PageSize { get; set; }

        public int Page { get; set; }

        public string? Cerca { get; set; }
    }
}
