using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace Anony.HttpRestRequest
{
    internal interface IHttpRestRequest
    {
        HttpRestResponse Execute(HttpMethod method, string pathAndQuery, string data);
    }
}