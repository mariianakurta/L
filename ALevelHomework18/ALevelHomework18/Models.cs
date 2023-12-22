using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Module4_Exercise1.ReqresApiExample.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Module4_Exercise1.ReqresApiExample.Models
{
    internal sealed class ReqresUserRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Avatar { get; set; }
    }

    internal sealed class UserCreatedResponse
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int? Id { get; set; }
        public System.DateTime? CreatedAt { get; set; }
    }

    internal sealed class CreateUserParametersRequest
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }

    internal sealed class ReqresPageResponse
    {

    }

    internal sealed class UserUpdateData
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }

    internal sealed class PartialUserUpdateData
    {
        public string Job { get; set; }
    }
}
