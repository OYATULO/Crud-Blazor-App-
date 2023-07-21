using Api_Company.IData.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models_Company;

namespace Api_ct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private protected readonly IContact contact;
        public ContactController(IContact contact)
        {
            this.contact = contact;
        }
        [HttpGet]
        public async Task<IEnumerable<Contact>> GetList() => await contact.Getlist();
        [HttpPost]
        public async Task<ActionResult> InsertAsync(Contact ct) => await contact.InsertNew(ct) ? Ok("Успешно добавлено!") : NotFound("Не добавлено");


        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult> GetctByID(Guid Id)
        {
            var result = await contact.GetById(Id);
            if (result == null) return NotFound("Ненайдено");
           else return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Updatect(Contact ct) => await contact.UpdateById(ct) ? Ok("Успешно обновлено!") : NotFound("Ненайдено");

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteById(Guid Id) => await contact.DeleteById(Id) ? Ok("Успешно удален!") : NotFound("Ненайдено");

        [HttpGet("{CompanyId}")]
        public async Task<ActionResult> CompanyId(Guid Id)
        {
            var result = await contact.GetByCompanyId(Id);
            if (!result.Any()) return NotFound("Ненайдено");
           else return Ok(result);
        }
    }
}
