using Api_Company.Context;
using Api_Company.IData.Contracts;
using Microsoft.EntityFrameworkCore;
using Models_Company;

namespace Api_Company.IData
{
    public class DataContacts : IContact
    {
        private readonly AppDbContext DataContext;
        public DataContacts(AppDbContext db)
        {
            DataContext = db;
        }

        public async Task<IEnumerable<Contact>> Getlist() => await DataContext.Contacts.ToListAsync() ?? null!;
        public async Task<Contact> GetById(Guid id)=>await DataContext.Contacts.FirstOrDefaultAsync(x => x.Id == id)??null!;
        public async Task<bool> InsertNew(Contact company)
        {
            try
            {
                await DataContext.AddAsync(company);
                return await DataContext.SaveChangesAsync()>=1;
            }
            catch { return false; }
        }

        public async Task<bool> UpdateById(Contact company)
        {
            try
            {
                 DataContext.Update(company);
                 return await DataContext.SaveChangesAsync()>=1;
            }
            catch { return false; }
          
        }
        public async Task<bool> DeleteById(Guid id)
        {
            try
            {
               DataContext.Remove(await GetById(id));
                return await DataContext.SaveChangesAsync() >= 1;
            }
            catch { return false; }
        }

        public async Task<IEnumerable<Contact>> GetByCompanyId(Guid id) => await DataContext.Contacts.Where(x => x.CompanyId == id).ToListAsync();
      
    }
}
