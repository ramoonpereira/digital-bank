using DigitalBank.Migrations.Models.DigitalAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.MigrationsSetup
{
    public class DigitalAccountSetup : IEntityTypeConfiguration<DigitalAccountModel>
    {
        public void Configure(EntityTypeBuilder<DigitalAccountModel> builder)
        {
            builder.ToTable("digital_account");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("INT(11)")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.CreatedDate)
               .HasColumnName("created_at")
               .HasColumnType("DATETIME")
               .ValueGeneratedOnAdd();

            builder.Property(c => c.Number)
                .IsRequired()
                .HasColumnName("number")
                .HasColumnType("INT(16)");

            builder.Property(c => c.Digit)
                .IsRequired()
                .HasColumnName("digit")
                .HasColumnType("CHAR(1)");

            builder.Property(c => c.Balance)
                .HasColumnName("balance")
                .HasColumnType("DECIMAL(10,2)");

            builder.Property(c => c.TransferLimitTransaction)
                .HasColumnName("transfer_limit_transaction")
                .HasColumnType("DECIMAL(10,2)");

            builder.Property(c => c.TransferLimitTransactionDay)
                .HasColumnName("transfer_limit_transaction_day")
                .HasColumnType("DECIMAL(10,2)");

            builder.Property(c => c.Status)
                .IsRequired()
                .HasColumnName("status")
                .HasColumnType("BOOLEAN");

        }
    }
}
