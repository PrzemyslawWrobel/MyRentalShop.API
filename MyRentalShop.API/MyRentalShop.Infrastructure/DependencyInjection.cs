 using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRentalShop.Application.Common.Interfaces;
using MyRentalShop.Infrastructure.ExternalApi.Teryt.API;
using MyRentalShop.Infrastructure.FileStore;
using MyRentalShop.Infrastructure.Services;
using System;

namespace MyRentalShop.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			//TODO po implementacji mtody  w TerytClient podać nazwę s klienta http

			//Konfiguracja cklienta http do zewnętrznego api
			//services.AddHttpClient("TerytClient", options =>
			//{ 
			//	options.BaseAddress = new Uri("http://www.example.com");
			//	options.Timeout = new TimeSpan(0, 0, 10);
			//	options.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
			//}).ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler()) ;

			services.AddScoped<TerytClient, TerytClient>();

			services.AddTransient<IFileStore, FileStore.FileStore >();
			services.AddTransient<IDateTime, DateTimeService>();
			services.AddTransient<IFileWrapper, FileWrapper>();
			services.AddTransient<IDirectoryWrapper, DirectoryWrapper>();
			return services;
		}
	}
}
