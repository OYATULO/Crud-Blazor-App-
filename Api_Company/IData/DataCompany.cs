using Api_Company.Context;
using Api_Company.IData.Contracts;
using Microsoft.EntityFrameworkCore;
using Models_Company;

namespace Api_Company.IData
{
    public class DataCompany : ICompany
    {
        private readonly AppDbContext DataContext = default!;
        public DataCompany(AppDbContext db)
        {
            DataContext = db;
        }

        #region Repository of Company
        //Get list Company
        public async Task<IEnumerable<MCompany>> Getlist() => await DataContext.Companies.ToListAsync() ?? null!;

        //Insert New data Company
        public async Task<bool> InsertNew(MCompany company)
        {
            try
            {
                await DataContext.Companies.AddAsync(company);
                return await DataContext.SaveChangesAsync() >= 1;
            }
            catch { return false; }
        }

        //Delete by id 
        public async Task<bool> DeleteById(Guid id)
        {
            try
            {
                DataContext.Remove(await GetById(id));
                return await DataContext.SaveChangesAsync() >= 1;
            }
            catch { return false; }
        }
        //Get By id
        public async Task<MCompany> GetById(Guid id) => await DataContext.Companies.FirstOrDefaultAsync(x => x.Id == id) ?? null!;
        public async Task<bool> UpdateById(MCompany mCompany)
        {
            try
            {
                DataContext.Update(mCompany);
                return await DataContext.SaveChangesAsync() >= 1;
            }
            catch { return false; }
        }
        #endregion
    }
}
