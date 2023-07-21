using Api_Company.IData.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models_Company;

namespace Api_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly IComunication ICom;
        public CommunicationController(IComunication comunication)
        {
            ICom = comunication;
        }
        [HttpGet]
        public async Task<IEnumerable<Communication>> GetComList() => await ICom.Getlist();

        [HttpPost]
        public async Task<ActionResult> InsertAsync(Communication cm) => await ICom.InsertNew(cm) ? Ok("Успешно добавлено!") : NotFound("Ненайдено");
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetComByID(Guid Id)
        {
            var result = await ICom.GetById(Id);
            if (result == null) return NotFound("Ненайдено");
            else return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateCom(Communication cm) => await ICom.UpdateById(cm) ? Ok("Успешно обновлено!") : NotFound("Ненайдено");

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteById(Guid Id) => await ICom.DeleteById(Id) ? Ok("Успешно удален!") : NotFound("Ненайдено");

        [HttpGet("company/{Id}")]
        public async Task<ActionResult> GetByIdCompany(Guid id)
        {
            var result =await ICom.GetByCompanyId(id);
            if (!result.Any()) return NotFound("Ненайдено");
            else  return Ok(result);
        }

        [HttpGet("contact{Id}")]
        public async Task<ActionResult> GetByIdContact(Guid id)
        {
            var result = await ICom.GetByContactId(id);
            if (!result.Any()) return NotFound("Ненайдено");
            else return Ok(result);
        }

    }
}
