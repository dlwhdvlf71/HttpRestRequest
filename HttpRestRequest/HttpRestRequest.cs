using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
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

        public HttpRestRequest()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

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
                Console.WriteLine("START");

                #region Validation Check

                if(header.Count <= 0)
                {
                    throw new Exception("header 설정이 안되어 있습니다");
                }

                #endregion

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(this.BaseUrl, pathAndQuery));

                this.header.GetHeaderList().ToList().ForEach(x => request.Headers.Add(x.Key, x.Value));

                request.Timeout = TimeOut;
                request.Method = method.ToString();

                if (!string.IsNullOrEmpty(data))
                {
                    request.ContentLength = data.Length;

                    byte[] sendData = this.RequestEncoding.GetBytes(data);

                    //Stream requestStream = null;

                    using(Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(sendData, 0, sendData.Length);
                        requestStream.Close();
                    }
                }

                Console.WriteLine("Response");

                // 응답 호출
                //StreamReader responseStreamReader;
                ////HttpWebResponse response = null;
                //WebResponse response;
                string returnData = string.Empty;



                WebResponse response = request.GetResponse();

                HttpWebResponse webResponse = (HttpWebResponse)response;
               

                //HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                //Console.WriteLine(response.StatusCode.ToString());

                //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                //{
                //    Console.WriteLine(response.StatusCode.ToString());

                //    //using (StreamReader responseStreamReader = new StreamReader(response.GetResponseStream()))
                //    //{
                //    //    returnData = responseStreamReader.ReadToEnd();
                //    //}
                //}

                //using (response = request.GetResponse())
                //{
                //    using (responseStreamReader = new StreamReader(response.GetResponseStream()))
                //    {
                //        returnData = responseStreamReader.ReadToEnd();
                //    }

                //}

                Console.WriteLine("returnData : " + returnData);

                HttpRestResponse returnResponse = new HttpRestResponse()
                {
                    
                };




            }
            catch(WebException wex)
            {
                Console.WriteLine(((int)((HttpWebResponse)wex.Response).StatusCode).ToString());

                var pageContent = new StreamReader(wex.Response.GetResponseStream())
                          .ReadToEnd();
                
                Console.WriteLine(pageContent.ToString());
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                Console.WriteLine("error line : " + line.ToString());



                throw;
            }
        }

    }
}






