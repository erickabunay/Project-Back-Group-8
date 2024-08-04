namespace API_ElectroUG.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }
        public string PublicMessage { get; set; }

        public ApiException(string message, int statusCode = 400, string publicMessage = null)
            : base(message)
        {
            StatusCode = statusCode;
            PublicMessage = publicMessage ?? message;
        }
    }
}
