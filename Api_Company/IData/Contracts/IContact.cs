using Models_Company;

namespace Api_Company.IData.Contracts
{
    public interface IContact
    {
        Task<IEnumerable<Contact>> Getlist();
        Task<Contact> GetById(Guid id);
        Task<bool> InsertNew(Contact Com);
        Task<bool> UpdateById(Contact Com);
        Task<bool> DeleteById(Guid id);

        //select by Foreigne 
        Task<IEnumerable<Contact>> GetByCompanyId(Guid id);
     
    }
}
