using DigitalBank.Migration.DatabaseContext;
using DigitalBank.Migration.Models.Administrator;
using DigitalBank.Migration.Models.AdministratorPermission;
using DigitalBank.Migration.Models.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalBank.Migration
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();

            builder.AddDockerSecrets("/run/secrets", true);

            Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            services
             .AddDbContext<AppDbContext>(options =>
               options.UseMySql(Configuration["MYSQL_CONNECTIONSTRING"]))
             .BuildServiceProvider();

            var serviceProvider = services.BuildServiceProvider();

            var context = serviceProvider.GetRequiredService<AppDbContext>();

            context.Database.EnsureCreated();

            var permissions = context.Permissions.ToListAsync().Result;

            var permissionsCreate = new List<PermissionModel>();

            if (permissions.Count == 0)
            {
                permissionsCreate.AddRange(
                    new List<PermissionModel>()
                    {
                        new PermissionModel()
                        {
                            Module = "pub-digitalaccount",
                            Permissions = "pub-digitalaccount-r",
                            Type = Models.Permission.Enum.PermissionTypeEnum.Customer,
                            Created = true
                        },
                        new PermissionModel()
                        {
                            Module = "pub-transaction",
                            Permissions = "pub-transaction-r,pub-transaction-c",
                            Type = Models.Permission.Enum.PermissionTypeEnum.Customer,
                            Created = true
                        },
                        new PermissionModel()
                        {
                            Module = "adm-digitalaccount",
                            Permissions = "adm-digitalaccount-r",
                            Type = Models.Permission.Enum.PermissionTypeEnum.Admin,
                            Created = true
                        },
                        new PermissionModel()
                        {
                            Module = "adm-transaction",
                            Permissions = "adm-transaction-r",
                            Type = Models.Permission.Enum.PermissionTypeEnum.Admin,
                            Created = true
                        }
                    }
                );

                context.Permissions.AddRange(permissionsCreate);

                context.SaveChanges();
            }

            var administrators = context.Administrators.ToListAsync().Result;

            if(administrators.Count == 0 && permissionsCreate.Count > 0)
            {
                var admin = new AdministratorModel()
                {
                    Name = "Administrador",
                    Email = "administrador@digitalbank.com",
                    Password = "E2FC329F4D83FD7BA56CAD197DE451230418A6A40BA9793E1B16FF697CCC47B5",
                    Phone = 16999999999,
                    Document = 12345678910,
                    BirthDate = DateTime.Now,
                    Status = true
                };

                var newAdmin = context.Administrators.Add(admin);

                context.SaveChanges();

                foreach (var permission in permissionsCreate.Where(p=>p.Type == Models.Permission.Enum.PermissionTypeEnum.Admin))
                {
                    var adminPermission = new AdministratorPermissionModel()
                    {
                        AdministratorId = newAdmin.Entity.Id,
                        PermissionId = permission.Id,
                        Permissions = permission.Permissions,
                    };
                    context.AdministratorPermissions.Add(adminPermission);
                    context.SaveChanges();
                }
            }
        }
    }
}
