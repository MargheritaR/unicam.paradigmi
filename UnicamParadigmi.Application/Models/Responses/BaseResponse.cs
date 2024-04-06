using System.Text.Json.Serialization;

namespace UnicamParadigmi.Application.Models.Responses
{
    public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; set; } = null;

        public T? Result { get; set; } = default;



    }
}
