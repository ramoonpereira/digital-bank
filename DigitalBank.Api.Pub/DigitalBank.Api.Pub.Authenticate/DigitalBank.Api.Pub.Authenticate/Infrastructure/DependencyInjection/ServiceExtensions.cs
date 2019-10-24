using AutoMapper;
using DigitalBank.Api.Pub.Authenticate.Business.Implementations;
using DigitalBank.Api.Pub.Authenticate.Business.Interfaces;
using DigitalBank.Api.Pub.Authenticate.Business.Repository;
using DigitalBank.Api.Pub.Authenticate.Infrastructure.AutoMapper;
using DigitalBank.Api.Pub.Authenticate.Repository;
using DigitalBank.Api.Pub.Authenticate.Repository.DbContext;
using DigitalBank.Api.Pub.Authenticate.Security.Encryptor.Handler;
using DigitalBank.Api.Pub.Authenticate.Security.Encryptor.Handler.Interfaces;
using DigitalBank.Api.Pub.Authenticate.Security.JWT.Handler.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalBank.Api.Pub.Authenticate.Infrastructure.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterWebApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(configuration["Application:Version"],
                    new Info
                    {
                        Title = configuration["Application:Title"],
                        Version = configuration["Application:Version"],
                        Description = configuration["Application:Description"]
                    });

                options.AddSecurityDefinition("bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Autenticação baseada em Json Web Token (JWT)",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
                var applicationName = PlatformServices.Default.Application.ApplicationName;
                var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");

                if (File.Exists(xmlDocumentPath))
                {
                    options.IncludeXmlComments(xmlDocumentPath);
                }
                options.DescribeAllEnumsAsStrings();
            });
            #endregion

            #region JWT
            var key = Encoding.ASCII.GetBytes(configuration["Security:JwtSecret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Application

            #region Repository
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            #endregion

            #region Handler
            services.AddSingleton<IEncryptorHandler, EncryptorHandler>();
            services.AddSingleton<ITokenHandler, Security.JWT.Handler.TokenHandler>();
            #endregion

            #region Business
            services.AddScoped<IAuthenticateBusiness, AuthenticateBusiness>();
            services.AddScoped<ICustomerBusiness, CustomerBusiness>();
            services.AddScoped<IPermissionBusiness, PermissionBusiness>();
            #endregion

            #endregion

            return services;
        }

        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MySQL:Connection"];

            services.AddDbContext<AppDbContext>(options =>
               options.UseMySql(connectionString));

            return services;
        }
    }
}
