using System;
using Application.DTOs;
using Application.Service.Client.Interfaces;
using Application.Service.Order;
using Microsoft.Extensions.DependencyInjection;
using Domain.ArchPatterns.UnitOfWork;
using Infrastructure.Database.ArchPatterns.Repositories;
using Infrastructure.Database.EntityFramework;
using Domain.ArchPatterns.Repositories.OrderRepository;
using Domain.ArchPatterns.Repositories.IClientRepository;
using Infrastructure.Tools;
using Domain.DomainEvents.Order.Interfaces;
using Application.Service.Order.Interfaces;
using Application.Service.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.IOC.ContainerDI
{
    public static class DI
    {
        private static IServiceProvider _serviceProvider;

        static DI()
        {
            var services = new ServiceCollection();
            RegisterServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            RegisterDatabaseServices(services);
            RegisterRepositories(services);
            RegisterServicesLayer(services);
            RegisterTools(services);

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        private static void RegisterDatabaseServices(IServiceCollection services)
        {
            services.AddScoped<DataContext>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void RegisterServicesLayer(IServiceCollection services)
        {
            services.AddScoped<IOrderServiceAplication, OrderServiceAplication>();
            services.AddScoped<IClienteServiceApplication, ClientServiceApplication>();
        }

        private static void RegisterTools(IServiceCollection services)
        {
            services.AddScoped<ISendEmail, SendEmail>();
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }

            
        //Metodo de extensao.
        public static IServiceCollection AddInfraStructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            RegisterServices(services);

            services.AddAutoMapper(typeof(AutoMapperProfile));

            //var sqlConnection = configuration.GetConnectionString("DefaultConnection");

            //services.AddDbContext<DataContext>(options =>
            //options.UseSqlServer(sqlConnection));

            return services;
        }
    }
}