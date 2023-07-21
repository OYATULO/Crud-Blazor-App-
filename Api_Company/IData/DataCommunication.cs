using Api_Company.Context;
using Api_Company.IData.Contracts;
using Microsoft.EntityFrameworkCore;
using Models_Company;

namespace Api_Company.IData
{
    public class DataCommunication : IComunication
    {

        private readonly AppDbContext DataContext;
        public DataCommunication(AppDbContext context) {
            DataContext = context;
        }
        public async Task<IEnumerable<Communication>> Getlist() => await DataContext.Communications.ToListAsync() ?? null!;
        public async Task<Communication> GetById(Guid id) => await DataContext.Communications.FirstOrDefaultAsync(x => x.Id == id) ?? null!;
        public async Task<bool> InsertNew(Communication Com)
        {
            try
            {
                await DataContext.AddAsync(Com);
                return await DataContext.SaveChangesAsync() >= 1;
            }
            catch { return false; }
        }

        public async Task<bool> UpdateById(Communication Com)
        {
            try
            {
                DataContext.Update(Com);
                return await DataContext.SaveChangesAsync() >= 1;
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

        public async Task<IEnumerable<Communication>> GetByCompanyId(Guid id) => await DataContext.Communications.Where(x => x.CompanyId == id).ToListAsync();

        public async Task<IEnumerable<Communication>> GetByContactId(Guid id) =>await DataContext.Communications.Where(x=>x.ContacId == id).ToListAsync();
            
    }
}
