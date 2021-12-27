using System.Net;
using System.Runtime.Serialization;

namespace Anony.HttpRestRequest
{
    public class HttpRestResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Data { get; set; }
    }
}