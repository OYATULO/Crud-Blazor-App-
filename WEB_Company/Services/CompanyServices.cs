using Models_Company;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WEB_Company.Services.Contracts;

namespace WEB_Company.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly HttpClient HClient;

        public CompanyServices(HttpClient httpClient)=>HClient = httpClient;

        public async Task<IEnumerable<MCompany>> Getlist() => (await HClient.GetFromJsonAsync<IEnumerable<MCompany>>("api/Company"))!;
        public async Task<bool> InsertNew(MCompany Com)
        {
            var json =new StringContent(JsonSerializer.Serialize(Com),Encoding.UTF8,"application/json");
            var response = await HClient.PostAsync("api/Company", json);
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }
        public async Task<MCompany> GetById(Guid id)
        {
            var data =    await HClient.GetFromJsonAsync<MCompany>($"api/Company/{id}") ?? null!;
            return data;
        }
        public async Task<bool> DeleteById(Guid id)
        {
            var result = await HClient.DeleteAsync($"api/Company/{id}");
            if (result.IsSuccessStatusCode)
                return true;
           else return false;
        }
        public async Task<bool> UpdateById(MCompany Com)
        {
            var json = new StringContent(JsonSerializer.Serialize(Com), Encoding.UTF8, "application/json");
            var result = await HClient.PutAsync("api/Company/Update", json);
           if (result.IsSuccessStatusCode) return true;
           else return false;
        }
    }
}
