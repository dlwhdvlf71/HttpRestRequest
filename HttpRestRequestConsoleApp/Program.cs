using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Anony.HttpRestRequest;

namespace HttpRestRequestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpRestRequest request = new HttpRestRequest("http://www.test.com");

            Header header = new Header();

            List<HeaderParser> headers = new List<HeaderParser> { { new HeaderParser { Key = "test", Value = "1" } } };

            header.Add(headers);


            headers = new List<HeaderParser> { { new HeaderParser { Key = "test", Value = "2" } } };

            header.Add(headers);

            request.header = header;

            foreach (HeaderParser hp in request.header.GetHeaderList())
            {
                Console.WriteLine($"key : {hp.Key} value : {hp.Value}");
            }

            //foreach(HeaderParser hc in request.header.)


            request.Create(HttpMethod.Get, "/api/pd/1/listNonDelivery.ssg", string.Empty);


        }
    }
}
