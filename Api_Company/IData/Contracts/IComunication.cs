using Models_Company;

namespace Api_Company.IData.Contracts
{
    public interface IComunication
    {
        Task<IEnumerable<Communication>> Getlist();
        Task<Communication> GetById(Guid id);
        Task<bool> InsertNew(Communication Com);
        Task<bool> UpdateById(Communication Com);
        Task<bool> DeleteById(Guid id);

        //get data whith foreign key 
        Task<IEnumerable<Communication>> GetByCompanyId(Guid id);
        Task<IEnumerable<Communication>> GetByContactId(Guid id);
    }
}
