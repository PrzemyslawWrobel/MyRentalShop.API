using System;

public static class DependencyInjection
{
	public static IserviceCollection AddInfrastructure(this IserviceCollection services, IConfiguration configuration)
	{
		return services;
	}
}
