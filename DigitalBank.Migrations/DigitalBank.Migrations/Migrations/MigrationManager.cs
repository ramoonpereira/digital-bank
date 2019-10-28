using DigitalBank.Migrations.DatabaseContext;
using DigitalBank.Migrations.Models.Administrator;
using DigitalBank.Migrations.Models.AdministratorPermission;
using DigitalBank.Migrations.Models.Permission;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Migrations.Migrations
{
    public static class MigrationManager
    {
        public static IWebHost MigrateDatabase(this IWebHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
                {
                    try
                    {
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
                            Type = PermissionTypeEnum.Customer,
                            Created = true
                        },
                        new PermissionModel()
                        {
                            Module = "pub-transaction",
                            Permissions = "pub-transaction-r,pub-transaction-c",
                            Type = PermissionTypeEnum.Customer,
                            Created = true
                        },
                        new PermissionModel()
                        {
                            Module = "adm-digitalaccount",
                            Permissions = "adm-digitalaccount-r",
                            Type = PermissionTypeEnum.Admin,
                            Created = true
                        },
                        new PermissionModel()
                        {
                            Module = "adm-transaction",
                            Permissions = "adm-transaction-r",
                            Type = PermissionTypeEnum.Admin,
                            Created = true
                        }
                                }
                            );

                            context.Permissions.AddRange(permissionsCreate);

                            context.SaveChanges();
                        }

                        var administrators = context.Administrators.ToListAsync().Result;

                        if (administrators.Count == 0 && permissionsCreate.Count > 0)
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

                            foreach (var permission in permissionsCreate.Where(p => p.Type == PermissionTypeEnum.Admin))
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
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }

            return webHost;
        }
    }
}
