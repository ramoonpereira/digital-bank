using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Customer;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.CustomerPermission;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.DigitalAccount.Business.Models.Permission;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Api.Pub.DigitalAccount.Repository.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionModel>()
                .Property(c => c.Type)
                .HasConversion<int>();

            modelBuilder.Entity<CustomerModel>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CustomerPermissionModel>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DigitalAccountModel>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PermissionModel>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CustomerModel>()
                .Property(b => b.CreatedDate)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CustomerPermissionModel>()
                .Property(b => b.CreatedDate)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DigitalAccountModel>()
                .Property(b => b.CreatedDate)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PermissionModel>()
                .Property(b => b.CreatedDate)
                .ValueGeneratedOnAdd();
        }

        public DbSet<DigitalAccountModel> DigitalAccounts { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<CustomerPermissionModel> CustomerPermissions { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }
    }
}
