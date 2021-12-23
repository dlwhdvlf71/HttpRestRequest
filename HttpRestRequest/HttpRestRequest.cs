using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Anony.HttpRestRequest
{
    public class HttpRestRequest : IHttpRestRequest
    {
        public string BaseUrl { get { return _baseUrl; } set { _baseUrl = value; } }

        private string _baseUrl { get; set; }

        public string Encoding { get; set; } = "UTF-8";

        public int TimeOut { get; set; } = 20000;

        public Header header { get; set; }

        public HttpRestRequest(string baseUri)
        {
            try
            {
                this.BaseUrl = baseUri;
                this.header = new Header();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Create(HttpMethod method, string pathAndQuery, string data)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Join(string.Empty, this.BaseUrl, pathAndQuery));

                //request.Headers = this.header;

                
                request.Method = method.ToString();

                

                //Console.WriteLine(request.ContentType.ToString());
                //Console.WriteLine(request.Headers.GetValues("Content-Type"));

                //using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                //{
                //    string responseData = string.Empty;

                //    using(StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                //    {
                //        responseData = streamReader.ReadToEnd();
                //    }

                //}



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Test()
        {
            throw new NotImplementedException();
        }

        public void HttpRequest(string url)
        {


        }
    }
}






