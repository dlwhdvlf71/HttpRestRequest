using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Anony.HttpRestRequest
{
    public class HttpRestResponse
    {
        [Required]
        public bool IsSuccess { get; set; } = false;

        [Required]
        [EnumDataType(typeof(HttpStatusCode))]
        public HttpStatusCode StatusCode { get; set; }

        public string StatusDescription { get; set; } = string.Empty;

        //public WebHeaderCollection Headers { get; set; }
        //public CookieCollection Cookies { get; set; }
        public string ContentType { get; set; } = string.Empty;

        public long ContentLength { get; set; } = 0;
        public string Data { get; set; } = string.Empty;
    }
}