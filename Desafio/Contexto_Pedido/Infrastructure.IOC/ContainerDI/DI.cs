using System;
using Microsoft.Extensions.DependencyInjection;
using Domain;
using Domain.ArchPatterns.UnitOfWork;
using Infrastructure.Database.ArchPatterns.Repositories;
using Infrastructure.Database.EntityFramework;
using Domain.ArchPatterns.Repositories.OrderRepository;
using Domain.ArchPatterns.Repositories.IClientRepository;

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
            services.AddScoped<ICreateOrderService, OrderService>();
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}