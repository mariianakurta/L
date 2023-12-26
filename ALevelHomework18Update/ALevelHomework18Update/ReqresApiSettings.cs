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
    public class ReqresApiSettings
    {
        public string BaseUrl { get; set; }
    }
}
