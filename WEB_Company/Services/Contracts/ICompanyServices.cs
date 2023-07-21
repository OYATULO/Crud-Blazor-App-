using Models_Company;
using System.Net;

namespace WEB_Company.Services.Contracts
{
    public interface ICompanyServices
    {
        Task<IEnumerable<MCompany>> Getlist();
        Task<MCompany> GetById(Guid id);
        Task<bool> InsertNew(MCompany Com);
        Task<bool> UpdateById(MCompany Com);
        Task<bool> DeleteById(Guid id);
    }
}
