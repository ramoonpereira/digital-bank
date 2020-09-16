using DigitalBank.Migrations.MigrationsSetup;
using DigitalBank.Migrations.Models.Administrator;
using DigitalBank.Migrations.Models.AdministratorPermission;
using DigitalBank.Migrations.Models.Customer;
using DigitalBank.Migrations.Models.CustomerPermission;
using DigitalBank.Migrations.Models.DigitalAccount;
using DigitalBank.Migrations.Models.DigitalAccountTransaction;
using DigitalBank.Migrations.Models.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace DigitalBank.Migrations.DatabaseContext
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
