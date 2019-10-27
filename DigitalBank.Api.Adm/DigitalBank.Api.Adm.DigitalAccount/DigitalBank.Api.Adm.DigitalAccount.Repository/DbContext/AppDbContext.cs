using DigitalBank.Api.Adm.DigitalAccount.Business.Models.Customer;
using DigitalBank.Api.Adm.DigitalAccount.Business.Models.DigitalAccount;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Api.Adm.DigitalAccount.Repository.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerModel>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CustomerModel>()
                .Property(b => b.CreatedDate)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DigitalAccountModel>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DigitalAccountModel>()
                .Property(b => b.CreatedDate)
                .ValueGeneratedOnAdd();
        }

        public DbSet<DigitalAccountModel> DigitalAccounts { get; set; }
    }
}
