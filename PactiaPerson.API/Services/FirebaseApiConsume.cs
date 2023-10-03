using Newtonsoft.Json;
using System.Text;

namespace PactiaPerson.API.Services
{
    public class FirebaseApiConsume : IFirebaseApiConsume
    {
        private readonly HttpClient _httpClient;

        public FirebaseApiConsume(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> AddRecordAsync<T>(T record,int id)
        {
            var jsonString = JsonConvert.SerializeObject(record);
            var httpcontent = new StringContent(jsonString,Encoding.UTF8, "application/json");
            using var responseHttp = await _httpClient.PutAsync($"/{id}.json", httpcontent);
            var apiResponse = await responseHttp.Content.ReadAsStringAsync();
            return apiResponse;
        }

        public async Task<string> DeleteRecordAsync<T>(int id)
        {
            using var responseHttp = await _httpClient.DeleteAsync($"/{id}.json");
            var apiResponse = await responseHttp.Content.ReadAsStringAsync();
            return apiResponse;
        }

        public async Task<string> GetAllRecordsAsync()
        {
            using var responseHttp = await _httpClient.GetAsync("/.json");
            var apiResponse = await responseHttp.Content.ReadAsStringAsync();
            return apiResponse;
        }

        public async Task<string> GetRecordAsync<T>(int id)
        {
            using var responseHttp = await _httpClient.GetAsync($"/{id}.json");
            var apiResponse = await responseHttp.Content.ReadAsStringAsync();
            return apiResponse;
        }

        public async Task<string> UpdateRecordAsync<T>(T record, int id)
        {
            var jsonString = JsonConvert.SerializeObject(record);
            var httpcontent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using var responseHttp = await _httpClient.PutAsync($"/{id}.json", httpcontent);
            var apiResponse = await responseHttp.Content.ReadAsStringAsync();
            return apiResponse;
        }
    }
}
