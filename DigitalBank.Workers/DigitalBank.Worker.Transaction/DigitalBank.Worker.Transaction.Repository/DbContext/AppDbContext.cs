using DigitalBank.Worker.Transaction.Business.Models.DigitalAccount;
using DigitalBank.Worker.Transaction.Business.Models.DigitalAccountTransaction;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Worker.Transaction.Repository.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DigitalAccountTransactionModel>()
               .Property(b => b.Id)
               .ValueGeneratedOnAdd();

            modelBuilder.Entity<DigitalAccountTransactionModel>()
                 .Property(b => b.CreatedDate)
                 .ValueGeneratedOnAdd();

            modelBuilder.Entity<DigitalAccountTransactionModel>()
               .Property(c => c.Type)
               .HasConversion<int>();

            modelBuilder.Entity<DigitalAccountTransactionModel>()
                .Property(c => c.Operation)
                .HasConversion<int>();

            modelBuilder.Entity<DigitalAccountTransactionModel>()
                 .Property(c => c.Status)
                 .HasConversion<int>();

            modelBuilder.Entity<DigitalAccountModel>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DigitalAccountModel>()
                 .Property(b => b.CreatedDate)
                 .ValueGeneratedOnAdd();

            modelBuilder.Entity<DigitalAccountModel>()
                .HasMany(m => m.DigitalAccountTransactions)
                .WithOne(m=>m.DigitalAccount)
                .HasForeignKey(m => m.DigitalAccountId);

            modelBuilder.Entity<DigitalAccountModel>()
                .HasMany(m => m.DigitalAccountTransactionsSender)
                .WithOne(m => m.DigitalAccountSender)
                .HasForeignKey(m => m.DigitalAccountSenderId);

            modelBuilder.Entity<DigitalAccountTransactionModel>()
                .HasOne(m => m.DigitalAccount)
                .WithMany(m => m.DigitalAccountTransactions)
                .HasForeignKey(m => m.DigitalAccountId);

            modelBuilder.Entity<DigitalAccountTransactionModel>()
                .HasOne(m => m.DigitalAccountSender)
                .WithMany(m => m.DigitalAccountTransactionsSender)
                .HasForeignKey(m => m.DigitalAccountSenderId);

            modelBuilder.Entity<DigitalAccountTransactionModel>().Ignore(c => c.DigitalAccountSender);

            modelBuilder.Entity<DigitalAccountTransactionModel>().Ignore(c => c.DigitalAccount);

            modelBuilder.Entity<DigitalAccountModel>().Ignore(c => c.DigitalAccountTransactions);

            modelBuilder.Entity<DigitalAccountModel>().Ignore(c => c.DigitalAccountTransactionsSender);
        }

        public DbSet<DigitalAccountModel> DigitalAccounts { get; set; }
        public DbSet<DigitalAccountTransactionModel> DigitalAccountTransactions { get; set; }
    }
}
