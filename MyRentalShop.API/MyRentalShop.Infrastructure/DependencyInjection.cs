using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRentalShop.Application.Common.Interfaces;
using MyRentalShop.Infrastructure.FileStore;
using MyRentalShop.Infrastructure.Services;
using System;

namespace MyRentalShop.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<IFileStore, FileStore.FileStore >();
			services.AddTransient<IDateTime, DateTimeService>();
			services.AddTransient<IFileWrapper, FileWrapper>();
			services.AddTransient<IDirectoryWrapper, DirectoryWrapper>();
			return services;
		}
	}
}
