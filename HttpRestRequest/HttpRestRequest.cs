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

        private void SetHeader(ref HttpWebRequest httpWebRequest)
        {
            try
            {
                httpWebRequest.Headers.Clear();

                if (!string.IsNullOrEmpty(this.header.Accept))
                {
                    httpWebRequest.Accept = this.header.Accept;
                }

                if (!string.IsNullOrEmpty(this.header.Connection))
                {
                    httpWebRequest.Connection = this.header.Connection;
                }

                if (!this.header.ContentLength.Equals(0))
                {
                    httpWebRequest.ContentLength = this.header.ContentLength;
                }

                if (!string.IsNullOrEmpty(this.header.ContentType))
                {
                    httpWebRequest.ContentType = this.header.ContentType;
                }

                DateTime checkDateTime;

                if (this.header.Date != null)
                {
                    if (!DateTime.TryParse(this.header.Date.ToString(), out checkDateTime))
                    {
                        throw new FormatException();
                    }
                    httpWebRequest.Date = checkDateTime;
                }

                if (!string.IsNullOrEmpty(this.header.Expect))
                {
                    httpWebRequest.Expect = this.header.Expect;
                }

                if (!string.IsNullOrEmpty(this.header.Host))
                {
                    httpWebRequest.Host = this.header.Host;
                }

                if (this.header.IfModifiedSince != null)
                {
                    if (DateTime.TryParse(this.header.IfModifiedSince.ToString(), out checkDateTime))
                    {
                        throw new FormatException();
                    }

                    httpWebRequest.IfModifiedSince = checkDateTime;
                }

                if (!string.IsNullOrEmpty(this.header.Referer))
                {
                    httpWebRequest.Referer = this.header.Referer;
                }

                if (!string.IsNullOrEmpty(this.header.TransferEncoding))
                {
                    httpWebRequest.TransferEncoding = this.header.TransferEncoding;
                }

                if (!string.IsNullOrEmpty(this.header.UserAgent))
                {
                    httpWebRequest.UserAgent = this.header.UserAgent;
                }

                if (this.header.Proxy != null)
                {
                    httpWebRequest.Proxy = this.header.Proxy;
                }

                foreach(KeyValuePair<string, string> pair in this.header.GetList())
                {
                    httpWebRequest.Headers.Add(pair.Key, pair.Value);
                }

                //return this;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex : " + ex.Message);
                throw;
            }
        }

        public void Execute(HttpMethod method, string pathAndQuery, string data)
        {
            try
            {
                Console.WriteLine("START");

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(this.BaseUrl, pathAndQuery));

                this.SetHeader(ref request);

                //request.Header
                //this.header.GetHeaderList().ToList().ForEach(x => request.Headers.Add(x.Key, x.Value));

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


                Console.WriteLine(webResponse.StatusCode.ToString());

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






