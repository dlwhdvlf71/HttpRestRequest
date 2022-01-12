using System;
using System.Net;

namespace Anony.HttpRestRequest
{
    public class Header : WebHeaderCollection
    {
        public string Accept { get; set; }
        public string Connection { get; set; }
        public long ContentLength { get; set; }
        public string ContentType { get; set; }
        public DateTime? Date { get; set; }
        public string Expect { get; set; }
        public string Host { get; set; }
        public DateTime? IfModifiedSince { get; set; }
        public string Referer { get; set; }
        public string TransferEncoding { get; set; }
        public string UserAgent { get; set; }
        public WebProxy Proxy { get; set; }
    }
}