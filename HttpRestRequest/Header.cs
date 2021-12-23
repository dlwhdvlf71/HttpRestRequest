using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        #region Set

        public Header Set(HeaderParser headerParser)
        {
            try
            {
                return Set(headerParser.Key, headerParser.Value);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Header Set(string key, string value)
        {
            try
            {
                if (!_headers.Where(x => x.Key.Equals(key)).Any())
                {
                    throw new NullReferenceException();
                }

                _headers.Where(x => x.Key.Equals(key)).FirstOrDefault().Value = value;

                return this;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Header Set(ICollection<HeaderParser> headers)
        {
            try
            {
                _headers.Clear();

                foreach (HeaderParser headerParser in headers)
                {
                    _headers.Add(headerParser);
                }

                return this;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Get

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

        public string Get(string key)
        {
            try
            {
                if (!_headers.Any())
                {
                    return string.Empty;
                }

                if (!_headers.Where(x => x.Key.Equals(key)).Any())
                {
                    return string.Empty;
                }

                return _headers.Where(x => x.Key.Equals(key)).FirstOrDefault().Value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Add

        public Header Add(ICollection<HeaderParser> headers)
        {
            try
            {
                foreach (HeaderParser headerParser in headers)
                {
                    Add(headerParser);
                }

                return this;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Header Add(HeaderParser headerParser)
        {
            try
            {
                if (_headers.Any())
                {
                    foreach (HeaderParser hp in _headers.ToList())
                    {
                        if (hp.Key.Equals(headerParser.Key))
                        {
                            _headers.Remove(hp);
                        }
                    }
                }

                _headers.Add(headerParser);

                return this;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}