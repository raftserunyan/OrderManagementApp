using Microsoft.Extensions.DependencyInjection;
using OrderManagementApp.Data.Interfaces;
using OrderManagementApp.Repositories.Data;

namespace OrderManagementApp.Data.ServiceExtensions
{
    public static class DataServicesInjector
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
