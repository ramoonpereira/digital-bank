using DigitalBank.Migrations.Models.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.MigrationsSetup
{
    public class PermissionSetup : IEntityTypeConfiguration<PermissionModel>
    {
        public void Configure(EntityTypeBuilder<PermissionModel> builder)
        {
            builder.ToTable("permissions");

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

            builder.Property(c => c.Module)
                .IsRequired()
                .HasColumnName("module")
                .HasColumnType("VARCHAR(255)");

            builder.Property(c => c.CreatedDate)
                .HasColumnName("created")
                .HasColumnType("BOOLEAN");

            builder.Property(c => c.CreatedDate)
                .HasColumnName("created_at")
                .HasColumnType("TIMESTAMP")
                .ValueGeneratedOnAdd();
        }
    }
}
