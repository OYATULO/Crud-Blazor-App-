using Api_Company.IData.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models_Company;

namespace Api_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private protected readonly ICompany ICompanies;
        public CompanyController(ICompany icompany)
        {
            ICompanies = icompany;
        }

        [HttpGet]
        public async Task<IEnumerable<MCompany>> GetCompaniesAsync()=> await ICompanies.Getlist();

        [HttpPost]
        public async Task<ActionResult> InsertAsync(MCompany company)=> await ICompanies.InsertNew(company)? Ok("Успешно обновлено!") : NotFound("Ненайдено");
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetCompanyByID(Guid Id)
        {
            var result = await ICompanies.GetById(Id);
            if (result == null)  return NotFound("Ненайдено");
           else return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateCompany (MCompany company) => await ICompanies.UpdateById(company)? Ok("Успешно обновлено!") : NotFound("Ненайдено");

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteById(Guid Id)=>await ICompanies.DeleteById(Id)?Ok("Успешно удален!") : NotFound("Ненайдено");
      


    }
}
