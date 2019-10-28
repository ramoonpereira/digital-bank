
using DigitalBank.Migration.MigrationsSetup;
using DigitalBank.Migration.Models.Administrator;
using DigitalBank.Migration.Models.AdministratorPermission;
using DigitalBank.Migration.Models.Customer;
using DigitalBank.Migration.Models.CustomerPermission;
using DigitalBank.Migration.Models.DigitalAccount;
using DigitalBank.Migration.Models.DigitalAccountTransaction;
using DigitalBank.Migration.Models.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DigitalBank.Migration.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PermissionModel>(new PermissionSetup().Configure);
            modelBuilder.Entity<CustomerModel>(new CustomerSetup().Configure);
            modelBuilder.Entity<CustomerPermissionModel>(new CustomerPermissionSetup().Configure);
            modelBuilder.Entity<AdministratorModel>(new AdministratorSetup().Configure);
            modelBuilder.Entity<AdministratorPermissionModel>(new AdministratorPermissionSetup().Configure);
            modelBuilder.Entity<DigitalAccountModel>(new DigitalAccountSetup().Configure);
            modelBuilder.Entity<DigitalAccountTransactionModel>(new DigitalAccountTransactionSetup().Configure);
        }

        public DbSet<DigitalAccountTransactionModel> DigitalAccountTransactions { get; set; }
        public DbSet<DigitalAccountModel> DigitalAccounts { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<CustomerPermissionModel> CustomerPermissions { get; set; }
        public DbSet<AdministratorModel> Administrators { get; set; }
        public DbSet<AdministratorPermissionModel> AdministratorPermissions { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }
    }
}
