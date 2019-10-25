using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Api.Pub.Transaction.Business.Models.DigitalAccountTransaction;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Api.Pub.Transaction.Repository.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DigitalAccountTransactionModel>()
                .Property(c => c.Type)
                .HasConversion<int>();

            modelBuilder.Entity<DigitalAccountTransactionModel>()
                .Property(c => c.Operation)
                .HasConversion<int>();

            modelBuilder.Entity<DigitalAccountTransactionModel>()
                .Property(c => c.Status)
                .HasConversion<int>();

            modelBuilder.Entity<DigitalAccountTransactionModel>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DigitalAccountModel>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DigitalAccountModel>()
                .Property(b => b.CreatedDate)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DigitalAccountTransactionModel>()
                .Property(b => b.CreatedDate)
                .ValueGeneratedOnAdd();
        }

        public DbSet<DigitalAccountModel> DigitalAccounts { get; set; }
        public DbSet<DigitalAccountTransactionModel> DigitalAccountTransactions { get; set; }
    }
}
