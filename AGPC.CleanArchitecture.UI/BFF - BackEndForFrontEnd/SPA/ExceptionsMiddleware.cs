using AGPC.CleanArchitecture.Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AGPC.CleanArchitecture.SPA
{
    public class ExceptionsMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionsMiddleware> _logger;
        public ExceptionsMiddleware(ILogger<ExceptionsMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(UseCaseException uex)
            {
                await HandleUseCaseExceptionAsync(context, uex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var json = new
            {
                context.Response.StatusCode,
                Message = "An error occurred. Contact your administrator",
                Detailed = exception
            };
            
            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(json));
        }

        private static Task HandleUseCaseExceptionAsync(HttpContext context, UseCaseException useCaseException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var json = new
            {
                context.Response.StatusCode,
                Message = useCaseException.Message
            };

            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(json));
        }

    }
}
