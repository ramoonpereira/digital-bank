using DigitalBank.Migration.Models.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Migration.MigrationsSetup
{
    public class CustomerSetup : IEntityTypeConfiguration<CustomerModel>
    {
        public void Configure(EntityTypeBuilder<CustomerModel> builder)
        {
            builder.ToTable("customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("INT(16)")
                .ValueGeneratedOnAdd();


            builder.Property(c => c.CreatedDate)
                  .IsRequired()
                .HasColumnName("created_at")
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("VARCHAR(255)");


            builder.Property(c => c.Email)
                  .IsRequired()
                .HasColumnName("email")
                .HasColumnType("VARCHAR(255)");

            builder.Property(c => c.Password)
                  .IsRequired()
                .HasColumnName("password")
                .HasColumnType("TEXT");


            builder.Property(c => c.Phone)
                  .IsRequired()
                .HasColumnName("phone")
                .HasColumnType("BIGINT(20)");


            builder.Property(c => c.BirthDate)
                  .IsRequired()
                .HasColumnName("birth_date")
                .HasColumnType("DATE");


            builder.Property(c => c.Document)
                  .IsRequired()
                .HasColumnName("document")
                .HasColumnType("BIGINT(20)");


            builder.Property(c => c.Status)
                  .IsRequired()
                .HasColumnName("status")
                .HasColumnType("BOOLEAN");
        }
    }
}
