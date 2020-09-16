using DigitalBank.Migrations.Models.AdministratorPermission;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.MigrationsSetup
{
    public class AdministratorPermissionSetup : IEntityTypeConfiguration<AdministratorPermissionModel>
    {
        public void Configure(EntityTypeBuilder<AdministratorPermissionModel> builder)
        {
            builder.ToTable("administrator_permissions");

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
                .HasColumnType("DATETIME")
                .ValueGeneratedOnAdd();
        }
    }
}
