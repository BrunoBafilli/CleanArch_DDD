using System;
using Application.Service.Interfaces;
using Application.Service.Order;
using Microsoft.Extensions.DependencyInjection;
using Domain.ArchPatterns.UnitOfWork;
using Infrastructure.Database.ArchPatterns.Repositories;
using Infrastructure.Database.EntityFramework;
using Domain.ArchPatterns.Repositories.OrderRepository;
using Domain.ArchPatterns.Repositories.IClientRepository;
using Infrastructure.Tools;
using Domain.DomainEvents.Order.Interfaces;

namespace Infrastructure.IOC.ContainerDI
{
    public class DI
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

            // services.AddAutoMapper(typeof(AutoMapperProfile));
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
        }

        private static void RegisterTools(IServiceCollection services)
        {
            services.AddScoped<ISendEmail, SendEmail>();
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}