namespace CrossPay.ElasticSearch.Exceptions
{
    public class BaseException : Exception
    {
        public System.Net.HttpStatusCode httpStatusCode { get; set; } = System.Net.HttpStatusCode.InternalServerError;

        public BaseException(string message) : base(message) { }

        public BaseException(string message, Exception exception)
        {

        }
    }
}
