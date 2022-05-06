using Microsoft.Extensions.DependencyInjection;
using OrderManagementApp.Business.Interfaces;
using OrderManagementApp.Business.Services;

namespace OrderManagementApp.Business.Extensions
{
    public static class CustomServicesInjector
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ISupplierService, SupplierService>();

            return services;
        }
    }
}
