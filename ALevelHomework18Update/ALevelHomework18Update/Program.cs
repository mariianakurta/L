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
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddOptions()
                .Configure<ReqresApiSettings>(Configuration.GetSection("ReqresApiSettings"))
                .AddTransient<IApiClient, ApiClient>()
                .AddTransient<IReqresApi, ReqresApi>()
                .BuildServiceProvider();

            var reqresApi = serviceProvider.GetService<IReqresApi>();

            await reqresApi.ReqresModelsExampleAsync();
            await reqresApi.ReqresPostExampleAsync();
            await reqresApi.ReqresPutExampleAsync();
            await reqresApi.ReqresPatchExampleAsync();
            await reqresApi.ReqresDeleteExampleAsync();
        }
    }
}
