using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRentalShop.Application.Interfaces;
using MyRentalShop.Infrastructure.Services;
using System;

namespace MyRentalShop.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<IDataTime, DataTimeService>();
			return services;
		}
	}
}
