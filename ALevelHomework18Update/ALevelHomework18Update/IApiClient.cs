using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ALevelHomework18Update;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ALevelHomework18Update
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> GetAsync(string uri);
        Task<HttpResponseMessage> PostAsync(string uri, HttpContent content);
        Task<HttpResponseMessage> PutAsync(string uri, HttpContent content);
        Task<HttpResponseMessage> PatchAsync(string uri, HttpContent content);
        Task<HttpResponseMessage> DeleteAsync(string uri);
    }
}
