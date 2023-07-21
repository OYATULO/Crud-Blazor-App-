using Models_Company;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using WEB_Company.Services.Contracts;

namespace WEB_Company.Services
{
    public class ContactServices : IContactServices
    {
        private readonly HttpClient HClient;

        public ContactServices(HttpClient Hclient)=>HClient = Hclient;

        public async Task<IEnumerable<Contact>> Getlist() => (await HClient.GetFromJsonAsync<IEnumerable<Contact>>("api/Contact"))!;
        public async Task<bool> InsertNew(Contact Com)
        {
            var json = new StringContent(JsonSerializer.Serialize(Com), Encoding.UTF8, "application/json");
            var response = await HClient.PostAsync("api/Contact", json);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<Contact> GetById(Guid id)
        {
            var data = await HClient.GetFromJsonAsync<Contact>($"api/Contact/GetById/{id}") ?? null!;
            return data;
        }
        public async Task<bool> DeleteById(Guid id)
        {
            var result = await HClient.DeleteAsync($"api/Contact/{id}");
            if (result.IsSuccessStatusCode)
                return true;
            else return false;
        }
        public async Task<bool> UpdateById(Contact Com)
        {
            var json = new StringContent(JsonSerializer.Serialize(Com), Encoding.UTF8, "application/json");
            var result = await HClient.PutAsync("api/Contact/Update", json);
            if (result.IsSuccessStatusCode) return true;
            else return false;
        }

    }
}
