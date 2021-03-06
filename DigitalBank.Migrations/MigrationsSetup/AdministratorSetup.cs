﻿using DigitalBank.Migrations.Models.Administrator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.MigrationsSetup
{
    public class AdministratorSetup : IEntityTypeConfiguration<AdministratorModel>
    {
        public void Configure(EntityTypeBuilder<AdministratorModel> builder)
        {
            builder.ToTable("administrators");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("INT(11)")
                .ValueGeneratedOnAdd();


            builder.Property(c => c.CreatedDate)
                  .IsRequired()
                .HasColumnName("created_at")
                .HasColumnType("DATETIME")
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
