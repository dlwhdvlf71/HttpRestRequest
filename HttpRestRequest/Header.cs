using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;

namespace Anony.HttpRestRequest
{
    //[Serializable]
    //public class HeaderParser
    //{
    //    public string Key { get; set; }
    //    public string Value { get; set; }
    //}

    public class Header : WebHeaderCollection
    {
        public string Accept { get; set; }
        public string Connection { get; set; }
        public long ContentLength{ get; set; }
        public string ContentType { get; set; }
        public DateTime? Date{ get; set; }
        public string Expect{ get; set; }
        public string Host { get; set; }
        public DateTime? IfModifiedSince{ get; set; }
        public string Referer { get; set; }
        public string TransferEncoding{ get; set; }
        public string UserAgent { get; set; }
        public WebProxy Proxy { get; set; }

        public Header()
        {
            try
            {
                this.Accept = string.Empty;
                this.Connection = string.Empty;
                this.ContentLength = 0;
                this.ContentType = string.Empty;
                this.Date = null;
                this.Expect = string.Empty;
                this.Host = string.Empty;
                this.IfModifiedSince = null;
                this.Referer = string.Empty;
                this.TransferEncoding = string.Empty;
                this.UserAgent = string.Empty;
                this.Proxy = null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public Header SetHeader(ref HttpWebRequest httpWebRequest)
        //{
        //    try
        //    {
        //        httpWebRequest.Headers.Clear();

        //        if (!string.IsNullOrEmpty(this.Accept))
        //        {
        //            httpWebRequest.Accept = this.Accept;
        //        }

        //        if (!string.IsNullOrEmpty(this.Connection))
        //        {
        //            httpWebRequest.Connection = this.Connection;
        //        }

        //        if (!ContentLength.Equals(0))
        //        {
        //            httpWebRequest.ContentLength = this.ContentLength;
        //        }

        //        if (!string.IsNullOrEmpty(this.ContentType))
        //        {
        //            httpWebRequest.ContentType = this.ContentType;
        //        }

        //        DateTime checkDateTime;

        //        if (this.Date != null)
        //        {
        //            if (!DateTime.TryParse(this.Date.ToString(), out checkDateTime))
        //            {
        //                throw new FormatException();
        //            }
        //            httpWebRequest.Date = checkDateTime;
        //        }

        //        if (!string.IsNullOrEmpty(this.Expect))
        //        {
        //            httpWebRequest.Expect = this.Expect;
        //        }

        //        if (!string.IsNullOrEmpty(this.Host))
        //        {
        //            httpWebRequest.Host = this.Host;
        //        }

        //        if (this.IfModifiedSince != null)
        //        {
        //            if(DateTime.TryParse(this.IfModifiedSince.ToString(), out checkDateTime))
        //            {
        //                throw new FormatException();    
        //            }

        //            httpWebRequest.IfModifiedSince = this.IfModifiedSince;
        //        }

        //        if (!string.IsNullOrEmpty(this.Referer))
        //        {
        //            httpWebRequest.Referer = this.Referer;
        //        }

        //        if (!string.IsNullOrEmpty(this.TransferEncoding))
        //        {
        //            httpWebRequest.TransferEncoding = this.TransferEncoding;
        //        }

        //        if (!string.IsNullOrEmpty(this.UserAgent))
        //        {
        //            httpWebRequest.UserAgent = this.UserAgent;
        //        }

        //        if (this.Proxy != null)
        //        {
        //            httpWebRequest.Proxy = this.Proxy;
        //        }

        //        return this;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public ICollection<KeyValuePair<string, string>> GetList()
        //{
        //    try
        //    {
        //        return this.AllKeys.Select(x => new KeyValuePair<string, string>(x, this[x])).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public int Count
        //{
        //    get
        //    {
        //        try
        //        {
        //            return _headers.Count;
        //        }
        //        catch (Exception)
        //        {
        //            return 0;
        //        }
        //    }
        //}

        //private ICollection<HeaderParser> _headers;

        //public Header()
        //{
        //    _headers = new Collection<HeaderParser>();
        //}

        //#region Set

        //public Header Set(HeaderParser headerParser)
        //{
        //    try
        //    {
        //        return Set(headerParser.Key, headerParser.Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public Header Set(string key, string value)
        //{
        //    try
        //    {
        //        if (!_headers.Where(x => x.Key.Equals(key)).Any())
        //        {
        //            Add(key, value);
        //        }
        //        else
        //        {
        //            _headers.Where(x => x.Key.Equals(key)).FirstOrDefault().Value = value;
        //        }

        //        return this;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public Header Set(ICollection<HeaderParser> headers)
        //{
        //    try
        //    {
        //        _headers.Clear();

        //        foreach (HeaderParser headerParser in headers)
        //        {
        //            _headers.Add(headerParser);
        //        }

        //        return this;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //#endregion

        //#region Get

        //public ICollection<HeaderParser> GetHeaderList()
        //{
        //    try
        //    {
        //        return this._headers;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public string Get(string key)
        //{
        //    try
        //    {
        //        if (!_headers.Any())
        //        {
        //            return string.Empty;
        //        }

        //        if (!_headers.Where(x => x.Key.Equals(key)).Any())
        //        {
        //            return string.Empty;
        //        }

        //        return _headers.Where(x => x.Key.Equals(key)).FirstOrDefault().Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //#endregion

        //#region Add

        //public Header Add(ICollection<HeaderParser> headers)
        //{
        //    try
        //    {
        //        foreach (HeaderParser headerParser in headers)
        //        {
        //            Add(headerParser);
        //        }

        //        return this;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public Header Add(string key, string value)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
        //        {
        //            throw new NullReferenceException();
        //        }

        //        return Add(new HeaderParser { Key = key, Value = value });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public Header Add(HeaderParser headerParser)
        //{
        //    try
        //    {
        //        if (_headers.Any())
        //        {
        //            foreach (HeaderParser hp in _headers.ToList())
        //            {
        //                if (hp.Key.Equals(headerParser.Key))
        //                {
        //                    _headers.Remove(hp);
        //                }
        //            }
        //        }

        //        _headers.Add(headerParser);

        //        return this;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //#endregion
    }
}