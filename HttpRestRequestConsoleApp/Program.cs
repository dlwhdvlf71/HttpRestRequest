using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Anony.HttpRestRequest;
using Newtonsoft.Json.Linq;

namespace HttpRestRequestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //HttpRestRequest request = new HttpRestRequest("http://eapi.ssgadm.com");
            HttpRestRequest request = new HttpRestRequest("https://jsonplaceholder.typicode.com");
            //HttpRestRequest request = new HttpRestRequest("https://httpbin.org/get");

            //request.RequestEncoding = Encoding.UTF8;
            //request.ResponseEncoding = Encoding.UTF8;

            //Header header = new Header();

            ////header.Add(HttpRequestHeader.ContentType, "application/json");
            ///
            //header.ContentType = "application/json";
            //header.Accept = "";

            //request.header = header;

            HttpRestResponse restResponse = request.Execute(HttpMethod.Get, "/posts", string.Empty);

            Console.WriteLine($@"{restResponse.StatusCode} / {restResponse.Data} / {restResponse.StatusDescription}");

            return;

            
        }
    }
}
