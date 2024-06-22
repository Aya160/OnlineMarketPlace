
namespace OnlineStore.Web.ErrorHandeling
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
             400 => "Bad Requst, Try Agin",
             401 => "Bad Requst, Try Agin",
             404 => "Not Found",
             500 => "Internal Server Error, Contact with Store Admin",
             _ => null
            };
        }
    }
}
