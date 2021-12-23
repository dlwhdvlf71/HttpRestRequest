using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Anony.HttpRestRequest
{
    public class HeaderParser
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Header
    {
        private ICollection<HeaderParser> _headers;

        public Header()
        {
            _headers = new Collection<HeaderParser>();
        }

        public Header Add(ICollection<HeaderParser> headers)
        {
            try
            {
                foreach(HeaderParser headerParser in headers)
                {
                    Console.WriteLine("[BEFOR] " + _headers.Where(x => x.Key.Equals(headerParser.Key)).Count().ToString());

                    _headers.Select(x => x).ToList().RemoveAll(y => y.Key.Equals(headerParser.Key));

                    //_headers.Where(x => x.Key.Equals(headerParser.Key)).Select(y => y).ToList().Clear();

                    Console.WriteLine("[AFTER] " + _headers.Where(x => x.Key.Equals(headerParser.Key)).Count().ToString());

                    _headers.Add(headerParser);
                }

             

                return this;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ICollection<HeaderParser> GetHeaderList()
        {
            try
            {
                return this._headers;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
