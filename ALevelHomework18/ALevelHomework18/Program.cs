using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Module4_Exercise1.ReqresApiExample;
using Module4_Exercise1.ReqresApiExample.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Module4_Exercise1
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            await ReqresApi.ReqresModelsExampleAsync();
            await ReqresApi.ReqresPostExampleAsync();
            await ReqresApi.ReqresPutExampleAsync();
            await ReqresApi.ReqresPatchExampleAsync();
            await ReqresApi.ReqresDeleteExampleAsync();
        }
    }
}
