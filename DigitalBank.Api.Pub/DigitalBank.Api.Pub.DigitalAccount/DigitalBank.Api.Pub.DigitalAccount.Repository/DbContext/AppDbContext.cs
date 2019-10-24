using DigitalBank.Api.Pub.DigitalAccount.Business.Models.DigitalAccount;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Api.Pub.DigitalAccount.Repository.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<DigitalAccountModel> DigitalAccounts { get; set; }
    }
}
