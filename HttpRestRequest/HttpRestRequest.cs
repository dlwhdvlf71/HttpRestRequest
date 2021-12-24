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

        public Encoding RequestEncoding { get; set; } = Encoding.UTF8;

        public Encoding ResponseEncoding { get; set; } = Encoding.UTF8;

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

        public void Execute(HttpMethod method, string pathAndQuery, string data)
        {
            try
            {
                #region Validation Check

                if(header.Count <= 0)
                {
                    throw new Exception("header 설정이 안되어 있습니다");
                }

                #endregion

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(this.BaseUrl, pathAndQuery));

                //request.Headers = this.header;

                request.Timeout = TimeOut;
                request.Method = method.ToString();

                if (!string.IsNullOrEmpty(data))
                {
                    request.ContentLength = data.Length;

                    byte[] sendData = this.RequestEncoding.GetBytes(data);

                    Stream requestStream = null;

                    using(requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(sendData, 0, sendData.Length);
                        requestStream.Close();
                    }
                }

                // 응답 호출
                StreamReader responseStreamReader = null;
                string returnData = string.Empty;

                using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using(responseStreamReader = new StreamReader(response.GetResponseStream(), this.ResponseEncoding))
                    {
                        returnData = responseStreamReader.ReadToEnd();
                    }
                }

                HttpRestResponse returnResponse = new HttpRestResponse()
                {

                };




            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}






