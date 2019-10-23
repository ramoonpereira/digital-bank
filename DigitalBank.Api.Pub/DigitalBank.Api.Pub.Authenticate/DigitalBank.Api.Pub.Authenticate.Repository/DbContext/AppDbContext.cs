using DigitalBank.Api.Pub.Authenticate.Business.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Api.Pub.Authenticate.Repository.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
