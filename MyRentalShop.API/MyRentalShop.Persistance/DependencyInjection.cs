using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyRentalShop.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyRentalShopDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyRentalShopApiDatabase")));
            return services;
        }
    }
}
