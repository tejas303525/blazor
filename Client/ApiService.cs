using System.Net.Http.Json;
using proj1.Shared;

namespace proj1.Client.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }
        public async Task<List<UserHardcodedAccount>> GetUser()
        {
            var response = await _httpClient.GetAsync("api/User");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<UserHardcodedAccount>>();
        }

        public async Task DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/user/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}

