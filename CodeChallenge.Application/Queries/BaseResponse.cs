using CodeChallenge.Application.Models.Enums;

namespace CodeChallenge.Application.Queries
{
    public class BaseResponse
    {
        public BaseResponse()
        {
        }

        public BaseResponse(string errorMessage, StatusCode statusCode)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }

        public string ErrorMessage { get; private set; }

        public StatusCode StatusCode { get; private set; }
    }
}
