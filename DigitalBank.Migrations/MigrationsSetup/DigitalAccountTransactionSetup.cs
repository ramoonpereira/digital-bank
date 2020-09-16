using DigitalBank.Migrations.Models.DigitalAccountTransaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.MigrationsSetup
{
    public class DigitalAccountTransactionSetup : IEntityTypeConfiguration<DigitalAccountTransactionModel>
    {
        public void Configure(EntityTypeBuilder<DigitalAccountTransactionModel> builder)
        {
            builder.ToTable("digital_account_transactions");

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

            builder.Property(c => c.Value)
                .HasColumnName("value")
                .HasColumnType("DECIMAL(10,2)");

            builder.Property(c => c.Type)
                .IsRequired()
                .HasColumnName("type")
                .HasColumnType("INT(11)");

            builder.Property(c => c.Operation)
                .IsRequired()
                .HasColumnName("operation")
                .HasColumnType("INT(11)");

            builder.Property(c => c.Status)
                .IsRequired()
                .HasColumnName("status")
                .HasColumnType("INT(11)");

            builder.Property(c => c.ReleaseDate)
                .HasColumnName("release_at")
                .HasColumnType("DATETIME")
                .ValueGeneratedOnAdd();
        }
    }
}
