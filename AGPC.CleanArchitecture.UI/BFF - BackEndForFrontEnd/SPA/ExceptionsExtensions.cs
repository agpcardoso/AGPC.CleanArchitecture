using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.SPA
{
    
	public static class ExceptionsExtensions
	{
		public static IServiceCollection AddCentralizedExceptionHandlerMiddleware(this IServiceCollection services)
		{
			return services.AddTransient<ExceptionsMiddleware>();
		}

		public static void UseCentralizedExceptionHandlerMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ExceptionsMiddleware>();
		}
	}
}
