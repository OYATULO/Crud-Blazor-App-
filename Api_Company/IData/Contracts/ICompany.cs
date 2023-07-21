using Models_Company;

namespace Api_Company.IData.Contracts
{
    public interface ICompany
    {
            Task<IEnumerable<MCompany>> Getlist();
            Task<MCompany> GetById(Guid id);
            Task<bool> InsertNew(MCompany Com);
            Task<bool> UpdateById(MCompany Com);
            Task<bool> DeleteById(Guid id);
    }
}
