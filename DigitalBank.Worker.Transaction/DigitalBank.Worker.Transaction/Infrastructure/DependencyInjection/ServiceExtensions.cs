﻿using DigitalBank.Worker.Transaction.Business.Implementations;
using DigitalBank.Worker.Transaction.Business.Interfaces;
using DigitalBank.Worker.Transaction.Business.Repository;
using DigitalBank.Worker.Transaction.Eventbus.EventHandlers;
using DigitalBank.Worker.Transaction.Eventbus.Service;
using DigitalBank.Worker.Transaction.Repository;
using DigitalBank.Worker.Transaction.Repository.DbContext;
using GreenPipes;
using MassTransit;
using MassTransit.RabbitMqTransport.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBank.Worker.Transaction.Infrastructure.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterWebApiServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region Application

            #region Repository
            services.AddScoped<IDigitalAccountRepository, DigitalAccountRepository>();
            services.AddScoped<IDigitalAccountTransactionRepository, DigitalAccountTransactionRepository>();
            #endregion

            #region Business
            services.AddScoped<IDigitalAccountBusiness, DigitalAccountBusiness>();
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

        public static IServiceCollection RegisterBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<TransactionEventHandler>();

                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var uri = new Uri(configuration["RABBITMQ_HOST"]);

                    var host = cfg.Host(uri, hostConfigurator =>
                    {
                        hostConfigurator.Username(configuration["RABBITMQ_USER_NAME"]);
                        hostConfigurator.Password(configuration["RABBITMQ_PASSWORD"]);
                    });

                    cfg.ReceiveEndpoint(host, configuration["RABBITMQ_TRANSACTION_QUEUE"], ep =>
                    {
                        ((RabbitMqReceiveEndpointConfiguration)ep).EnablePriority(0);

                        ep.UseMessageRetry(e => e.Interval(int.Parse(configuration["RABBITMQ_TRANSACTION_COUNT"]),
                            TimeSpan.FromMinutes(int.Parse(configuration["RABBITMQ_TRANSACTION_RETRY"]))));

                        ep.Bind(configuration["RABBITMQ_TRANSACTION_EXCHANGE"], ex =>
                        {
                            ex.Durable = false;
                        });

                        ep.Consumer<TransactionEventHandler>(provider);
                    });

                }));
            });

            services.AddSingleton<IHostedService, BusService>();

            return services;
        }
    }
}
