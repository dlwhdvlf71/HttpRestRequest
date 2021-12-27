using System;
using System.Collections.Generic;
using System.Linq;
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
            HttpRestRequest request = new HttpRestRequest("http://eapi.ssgadm.com");

            //HttpRestRequest request = new HttpRestRequest("https://httpbin.org/get");

            request.RequestEncoding = Encoding.UTF8;
            request.ResponseEncoding = Encoding.UTF8;

            Header header = new Header();

            header.Add("Content-Type", "application/json");
            header.Add("Accept", "application/json");
            

            request.header = header;


            // GET TEST

            request.Execute(HttpMethod.Get, "/item/0.1/getItemList.ssg?sellStatCd=20&pageSize=100&page=1&regDtsStart=20211220", string.Empty);
            //request.Execute(HttpMethod.Get, string.Empty, string.Empty);


            return;

            // POST TEST
            JObject jObject = new JObject()
            {
                { "requestNonDelivery", new JObject(){
                    { "perdType", "1"},
                    { "perdStrDts", "20211220"},
                    { "perdEndDts", "20211227"}
                } }
            };

            request.Execute(HttpMethod.Post, "/api/pd/1/listNonDelivery.ssg", jObject.ToString());


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


            //Console.WriteLine(header.Count.ToString());

            

            //foreach(HeaderParser hc in request.header.)


            //request.Execute(HttpMethod.Get, "/api/pd/1/listNonDelivery.ssg", string.Empty);


        }
    }
}
