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
    public class ReqresApi : IReqresApi
    {
        private readonly IApiClient _apiClient;
        private readonly ReqresApiSettings _apiSettings;

        public ReqresApi(IApiClient apiClient, IOptions<ReqresApiSettings> apiSettings)
        {
            _apiClient = apiClient;
            _apiSettings = apiSettings.Value;
        }

        public async Task ReqresModelsExampleAsync()
        {
            HttpResponseMessage result = await _apiClient.GetAsync($"{_apiSettings.BaseUrl}api/users?page=2");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Ok Code from reqres site.");
                string content = await result.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                ReqresPageResponse pageRequest = JsonConvert.DeserializeObject<ReqresPageResponse>(content);

                if (pageRequest != null)
                {
                    Console.WriteLine(pageRequest.ToString());
                }
            }
        }

        public async Task ReqresPostExampleAsync()
        {
            var userParametersRequest = new CreateUserParametersRequest
            {
                Name = "Cat",
                Job = "Doctor"
            };

            string serializedUser = JsonConvert.SerializeObject(userParametersRequest, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            var stringContent = new StringContent(serializedUser, Encoding.Unicode, "application/json");

            HttpResponseMessage result = await _apiClient.PostAsync($"{_apiSettings.BaseUrl}api/users", stringContent);

            if (result.StatusCode == HttpStatusCode.Created)
            {
                Console.WriteLine("StatusCode Created");

                string content = await result.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                UserCreatedResponse userCreatedResponse = JsonConvert.DeserializeObject<UserCreatedResponse>(content);
                Console.WriteLine(userCreatedResponse!.Name);
            }
        }

        public async Task ReqresPutExampleAsync()
        {
            int userId = 1;
            var userDataToUpdate = new UserUpdateData { Name = "Cat", Job = "Doctor" };

            string serializedData = JsonConvert.SerializeObject(userDataToUpdate, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            HttpResponseMessage result = await _apiClient.PutAsync($"{_apiSettings.BaseUrl}api/users/{userId}", new StringContent(serializedData, Encoding.Unicode, "application/json"));
        }

        public async Task ReqresPatchExampleAsync()
        {
            int userId = 1;
            var partialUserDataToUpdate = new PartialUserUpdateData { Job = "Doctor" };

            string serializedData = JsonConvert.SerializeObject(partialUserDataToUpdate, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            HttpResponseMessage result = await _apiClient.PatchAsync($"{_apiSettings.BaseUrl}api/users/{userId}", new StringContent(serializedData, Encoding.Unicode, "application/json"));
        }

        public async Task ReqresDeleteExampleAsync()
        {
            int userIdToDelete = 555555;
            HttpResponseMessage result = await _apiClient.DeleteAsync($"{_apiSettings.BaseUrl}api/users/{userIdToDelete}");
        }

        public async Task<ReqresUserRequest> GetUserAsync(int userId)
        {
            HttpResponseMessage result = await _apiClient.GetAsync($"{_apiSettings.BaseUrl}api/users/{userId}");

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
