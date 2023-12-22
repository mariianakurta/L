using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Module4_Exercise1.ReqresApiExample.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Module4_Exercise1.ReqresApiExample
{
    internal static class ReqresApi
    {
        private const string RequesURL = "https://reqres.in/";

        public static async Task ReqresModelsExampleAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(RequesURL);

            HttpResponseMessage result = await client.GetAsync("api/users?page=2");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Ok Code from reqres site.");
                string content = await result.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                ReqresPageResponse pageRequest = JsonConvert.DeserializeObject<ReqresPageResponse>(content);

                if (pageRequest is not null)
                {
                    Console.WriteLine(pageRequest.ToString());
                }
            }
        }

        public static async Task ReqresPostExampleAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(RequesURL);

            var userParametersRequest = new CreateUserParametersRequest
            {
                Name = "Vlad",
                Job = "Software Engineer"
            };

            string serializedUser = JsonConvert.SerializeObject(userParametersRequest, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            var stringContent = new StringContent(serializedUser, Encoding.Unicode, "application/json");

            HttpResponseMessage result = await client.PostAsync("api/users", stringContent);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("StatusCode Created");

                string content = await result.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                UserCreatedResponse userCreatedResponse = JsonConvert.DeserializeObject<UserCreatedResponse>(content);
                Console.WriteLine(userCreatedResponse!.Name);
            }
        }

        public static async Task ReqresPutExampleAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(RequesURL);

            int userId = 1;
            var userDataToUpdate = new UserUpdateData { Name = "Cat", Job = "Doctor" };

            string serializedData = JsonConvert.SerializeObject(userDataToUpdate, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            HttpResponseMessage result = await client.PutAsync($"api/users/{userId}", new StringContent(serializedData, Encoding.Unicode, "application/json"));
        }

        public static async Task ReqresPatchExampleAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(RequesURL);

            int userId = 1;
            var partialUserDataToUpdate = new PartialUserUpdateData { Job = "Doctor" };

            string serializedData = JsonConvert.SerializeObject(partialUserDataToUpdate, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            HttpResponseMessage result = await client.PatchAsync($"api/users/{userId}", new StringContent(serializedData, Encoding.Unicode, "application/json"));
        }

        public static async Task ReqresDeleteExampleAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(RequesURL);

            int userIdToDelete = 555555;
            HttpResponseMessage result = await client.DeleteAsync($"api/users/{userIdToDelete}");
        }

        public static async Task<ReqresUserRequest> GetUserAsync(int userId)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(RequesURL);

            HttpResponseMessage result = await client.GetAsync($"api/users/{userId}");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                string content = await result.Content.ReadAsStringAsync();
                ReqresUserRequest user = JsonConvert.DeserializeObject<ReqresUserRequest>(content);
                return user;
            }

            return null;
        }
    }
}
