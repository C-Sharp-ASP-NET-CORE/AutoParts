using AutoParts.Core.Contracts;
using AutoParts.Core.Services;
using AutoParts.Infrastructure.Data;
using AutoParts.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApiServiceCollectionExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }

        public static IServiceCollection AddApiDbContexts(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AutoPartsDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
