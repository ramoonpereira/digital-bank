using AutoMapper;
using DigitalBank.Api.Adm.Transaction.Business.Implementations;
using DigitalBank.Api.Adm.Transaction.Business.Interfaces;
using DigitalBank.Api.Adm.Transaction.Business.Repository;
using DigitalBank.Api.Adm.Transaction.Infrastructure.AutoMapper;
using DigitalBank.Api.Adm.Transaction.Repository;
using DigitalBank.Api.Adm.Transaction.Repository.DbContext;
using DigitalBank.Api.Adm.Transaction.Security.Encryptor.Handler;
using DigitalBank.Api.Adm.Transaction.Security.Encryptor.Handler.Interfaces;
using DigitalBank.Api.Adm.Transaction.Security.JWT.Handler;
using DigitalBank.Api.Adm.Transaction.Security.JWT.Handler.Interfaces;
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

namespace DigitalBank.Api.Adm.Transaction.Infrastructure.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterWebApiServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region JWT
            services.AddAuthorization(options =>
            {
                options.AddPolicy("DigitalBank-Adm", policy => policy.RequireClaim("Authorization", "Adm-DigitalBank"));
            });

            string secret = configuration["JWT_SECRET"];
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            var tokenOptions = configuration.GetSection(nameof(AuthorizeOptions));
            var tokenValidationParameters = new TokenValidationParametersBuilder(tokenOptions, signingKey)
                .Build();

            services.Configure<AuthorizeOptions>(options =>
            {
                options.Issuer = tokenOptions[nameof(AuthorizeOptions.Issuer)];
                options.Audience = tokenOptions[nameof(AuthorizeOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = tokenValidationParameters;
            });
            #endregion

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

                options.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Autenticação baseada em Json Web Token (JWT)",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                    {
                        { "Bearer", new string[] { } }
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
            services.AddScoped<IDigitalAccountTransactionRepository, DigitalAccountTransactionRepository>();
            #endregion

            #region Handler
            services.AddSingleton<IEncryptorHandler, EncryptorHandler>();
            services.AddSingleton<ITokenHandler, Security.JWT.Handler.TokenHandler>();
            #endregion

            #region Business
            services.AddScoped<IDigitalAccountTransactionBusiness, DigitalAccountTransactionBusiness>();
            #endregion

            #endregion

            return services;
        }

        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MYSQL_CONNECTIONSTRING"];

            services.AddDbContext<AppDbContext>(options =>
               options.UseLazyLoadingProxies()
               .UseMySql(connectionString));

            return services;
        }
    }
}
