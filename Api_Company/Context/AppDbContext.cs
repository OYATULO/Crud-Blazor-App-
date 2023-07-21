using Microsoft.EntityFrameworkCore;
using Models_Company;

namespace Api_Company.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MCompany>().HasData(
            new MCompany
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                Comment = "hello it is new comment ",
                CreationTime = DateTime.Now.Date,
                DecisionMakerId = Guid.NewGuid(),
                Level  = MCompany.EnumType.Premium,
                ModificationTime  = DateTime.Now.Date,
            });
        }
        public DbSet<MCompany> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }    
        public DbSet<Communication> Communications { get; set; }
    }
}
