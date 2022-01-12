using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Anony.HttpRestRequest
{
    public static class Extension
    {
        public static ICollection<KeyValuePair<string, string>> GetList(this WebHeaderCollection headerCollection)
        {
            try
            {
                return headerCollection.AllKeys.Select(x => new KeyValuePair<string, string>(x, headerCollection[x])).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
