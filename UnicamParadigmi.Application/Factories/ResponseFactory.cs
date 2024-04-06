using UnicamParadigmi.Application.Models.Responses;

namespace UnicamParadigmi.Application.Factories
{
    public class ResponseFactory
    {
        public static BaseResponse<T> WithSuccess<T>(T result)
        {
            var response = new BaseResponse<T>();
            response.IsSuccess = true;
            response.Result = result;
            return response;
        }

        public static BaseResponse<T> WithError<T>(T result)
        {
            var response = new BaseResponse<T>();
            response.IsSuccess = false;
            response.Result = result;
            return response;
        }

        public static BaseResponse<string?> WithError(Exception exception)
        {
            var response = new BaseResponse<string>();
            response.IsSuccess = false;
            response.Errors = new List<string>()
            {
                exception.Message
            };
            return response;
        }

    }
}
