using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Anony.HttpRestRequest
{
    public class HttpRestRequest : IHttpRestRequest
    {
        public string BaseUrl
        { get { return _baseUrl; } set { _baseUrl = value; } }

        private string _baseUrl { get; set; }

        public Encoding RequestEncoding { get; set; } = Encoding.UTF8;

        public Encoding ResponseEncoding { get; set; } = Encoding.UTF8;

        public int TimeOut { get; set; } = 20000;

        public Header header { get; set; }

        private delegate HttpRestResponse ResponseDelegate(HttpMethod method, string pathAndQuery, string data);

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

                foreach (KeyValuePair<string, string> pair in this.header.GetList())
                {
                    httpWebRequest.Headers.Add(pair.Key, pair.Value);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public HttpRestResponse Execute([Required] HttpMethod method, string pathAndQuery, string data)
        {
            HttpRestResponse httpRestResponse = new HttpRestResponse();

            try
            {
                if (method == null)
                {
                    httpRestResponse.StatusCode = HttpStatusCode.BadRequest;
                    httpRestResponse.StatusDescription = "method 는 필수 입니다";

                    return httpRestResponse;
                }

                httpRestResponse = HttpRequest(method, pathAndQuery, data);

                return httpRestResponse;
            }
            catch (Exception ex)
            {
                httpRestResponse.StatusCode = HttpStatusCode.BadRequest;
                httpRestResponse.StatusDescription = ex.Message;

                return httpRestResponse;
            }
        }

        private HttpRestResponse HttpRequest(HttpMethod method, string pathAndQuery, string data)
        {
            HttpRestResponse httpRestResponse = new HttpRestResponse();

            string returnData = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(this.BaseUrl, pathAndQuery));

                this.SetHeader(ref request);

                request.Timeout = TimeOut;
                request.Method = method.ToString();

                if (!string.IsNullOrEmpty(data))
                {
                    request.ContentLength = data.Length;

                    byte[] sendData = this.RequestEncoding.GetBytes(data);

                    //Stream requestStream = null;

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(sendData, 0, sendData.Length);
                        requestStream.Close();
                    }
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    httpRestResponse.StatusCode = response.StatusCode;
                    httpRestResponse.StatusDescription = response.StatusDescription;
                    httpRestResponse.ContentType = response.ContentType;
                    httpRestResponse.ContentLength = response.ContentLength;

                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        httpRestResponse.Data = streamReader.ReadToEnd();
                    }
                }
            }
            catch (WebException wex)
            {
                httpRestResponse.StatusCode = HttpStatusCode.InternalServerError;
                httpRestResponse.StatusDescription = wex.Message;

                if (wex.Response != null)
                {
                    HttpWebResponse response = (HttpWebResponse)wex.Response;

                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        httpRestResponse.Data = streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                httpRestResponse.StatusCode = HttpStatusCode.InternalServerError;
                httpRestResponse.StatusDescription = HttpStatusCode.InternalServerError.ToString();
            }

            return httpRestResponse;
        }
    }
}