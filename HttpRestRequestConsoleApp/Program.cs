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

            //List<HeaderParser> headers = new List<HeaderParser> { { new HeaderParser { Key = "test", Value = "1" } } };

            //header.Add(headers);


            //headers = new List<HeaderParser> { { new HeaderParser { Key = "test", Value = "2" } } };

            //header.Add(headers);



            //List<HeaderParser> headers = new List<HeaderParser> { { new HeaderParser { Key = "test", Value = "1" } } };
            //headers.Add(new HeaderParser { Key = "test", Value = "2" });
            //headers.Add(new HeaderParser { Key = "test", Value = "3" });

            //header.Set(headers);


            //header.Add(headers);

            //header.Add(new HeaderParser() { Key = "test", Value = "4" });
            //header.Add(new HeaderParser() { Key = "test", Value = "5" });

            //header.Add("Content-Type", "application/json");

            //header.Set("test", "6");

            //request.header = header;


            //foreach (HeaderParser hp in request.header.GetHeaderList())
            //{
            //    Console.WriteLine($"key : {hp.Key} value : {hp.Value}");
            //}


            Console.WriteLine(header.Count.ToString());

            

            //foreach(HeaderParser hc in request.header.)


            //request.Execute(HttpMethod.Get, "/api/pd/1/listNonDelivery.ssg", string.Empty);


        }
    }
}
