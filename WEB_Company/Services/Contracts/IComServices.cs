using Models_Company;

namespace WEB_Company.Services.Contracts
{
    public interface IComServices
    {
        Task<IEnumerable<Communication>> Getlist();
        Task<Communication> GetById(Guid id);
        Task<bool> InsertNew(Communication Com);
        Task<bool> UpdateById(Communication Com);
        Task<bool> DeleteById(Guid id);
    }
}
