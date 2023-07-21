using Models_Company;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using WEB_Company.Services.Contracts;

namespace WEB_Company.Services
{
    public class CommunicationServices : IComServices
    {

        private readonly HttpClient HClient;

        public CommunicationServices(HttpClient httpClient)
        {
            HClient = httpClient;
        }
        public async Task<IEnumerable<Communication>> Getlist() => (await HClient.GetFromJsonAsync<IEnumerable<Communication>>("api/Communication"))!;
        public async Task<bool> InsertNew(Communication Com)
        {
            var json = new StringContent(JsonSerializer.Serialize(Com), Encoding.UTF8, "application/json");
            var response = await HClient.PostAsync("api/Communication", json);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<Communication> GetById(Guid id)
        {
            var data = await HClient.GetFromJsonAsync<Communication>($"api/Communication/{id}") ?? null!;
            return data;
        }
        public async Task<bool> DeleteById(Guid id)
        {
            var result = await HClient.DeleteAsync($"api/Communication/{id}");
            if (result.IsSuccessStatusCode)
                return true;
            else return false;
        }
        public async Task<bool> UpdateById(Communication Com)
        {
            var json = new StringContent(JsonSerializer.Serialize(Com), Encoding.UTF8, "application/json");
            var result = await HClient.PutAsync("api/Communication/Update", json);
            if (result.IsSuccessStatusCode) return true;
            else return false;
        }
    }
}
