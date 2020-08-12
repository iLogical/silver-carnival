using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SilverCarnival.Api.Extensions;

namespace SilverCarnival.Api.Middleware
{
    public class ErrorHandling
    {
        private readonly RequestDelegate _next;

        public ErrorHandling(RequestDelegate next)
        {
            _next = next;
        }
        
        // ReSharper disable once UnusedMember.Global // This is used by ASP.net Managed code
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = new {error = exception.Message};
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(result.Serialize());
        }
    }
}