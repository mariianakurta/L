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
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetAsync(string uri) => await _client.GetAsync(uri);
        public async Task<HttpResponseMessage> PostAsync(string uri, HttpContent content) => await _client.PostAsync(uri, content);
        public async Task<HttpResponseMessage> PutAsync(string uri, HttpContent content) => await _client.PutAsync(uri, content);
        public async Task<HttpResponseMessage> PatchAsync(string uri, HttpContent content) => await _client.PatchAsync(uri, content);
        public async Task<HttpResponseMessage> DeleteAsync(string uri) => await _client.DeleteAsync(uri);
    }
}
