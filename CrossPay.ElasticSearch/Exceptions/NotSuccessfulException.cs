using Elasticsearch.Net;
using System.Net;

namespace CrossPay.ElasticSearch.Exceptions
{
    [Serializable]
    public class NotSuccessfulException : BaseException
    {
        public NotSuccessfulException(string message) : base(message)
        {
            httpStatusCode = HttpStatusCode.BadRequest;
        }
    }
}
