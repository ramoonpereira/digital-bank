using DigitalBank.Migration.Models.CustomerPermission;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalBank.Migration.MigrationsSetup
{
    public class CustomerPermissionSetup : IEntityTypeConfiguration<CustomerPermissionModel>
    {
        public void Configure(EntityTypeBuilder<CustomerPermissionModel> builder)
        {
            builder.ToTable("customer_permissions");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("INT(11)")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Permissions)
                .IsRequired()
                .HasColumnName("permissions")
                .HasColumnType("TEXT");

            builder.Property(c => c.CreatedDate)
                .HasColumnName("created_at")
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAdd();
        }
    }
}
