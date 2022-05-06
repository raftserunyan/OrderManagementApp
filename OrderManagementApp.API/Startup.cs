using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderManagementApp.API.Middlewares;
using OrderManagementApp.Business.Extensions;
using OrderManagementApp.Data.ServiceExtensions;
using OrderManagementApp.Data;
using AutoMapper;
using OrderManagementApp.API.MapperProfiles;

namespace OrderManagementApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderManagementApp.API", Version = "v1" });
            });

            services.AddUnitOfWork();
            services.AddCustomServices();

            services.AddDbContext<OrderManagementAppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalDbConnectionString")));

            services.AddAutoMapper(typeof(SupplierProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderManagementApp.API v1"));
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
