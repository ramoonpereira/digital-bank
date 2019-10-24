using DigitalBank.Api.Pub.Authenticate.Business.Models.Customer;
using DigitalBank.Api.Pub.Authenticate.Business.Models.Permission;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Api.Pub.Authenticate.Repository.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }
    }
}
