using Models_Company;

namespace WEB_Company.Services.Contracts
{
    public interface IContactServices
    {
        Task<IEnumerable<Contact>> Getlist();
        Task<Contact> GetById(Guid id);
        Task<bool> InsertNew(Contact Con);
        Task<bool> UpdateById(Contact Con);
        Task<bool> DeleteById(Guid id);
    }
}
