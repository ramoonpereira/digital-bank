using DigitalBank.Api.Adm.Authenticate.Business.Models.Administrator;
using DigitalBank.Api.Adm.Authenticate.Business.Models.Permission;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Api.Adm.Authenticate.Repository.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<AdministratorModel> Administrators { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }
    }
}
