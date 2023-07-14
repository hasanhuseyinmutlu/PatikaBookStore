using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next,ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + "-" + context.Request.Path;
                _loggerService.Write(message);
                await _next(context);
                watch.Stop();
                message = "[Response] HTTP" + context.Request.Method + "-" + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.ElapsedMilliseconds + " ms ";
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {

                watch.Stop();
                await HandleExeption(context, ex,watch);
            }
        }

        private Task HandleExeption(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json"; 
            string message = "[Error]  HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + ex.Message + " in " +watch.ElapsedMilliseconds + " ms";
            System.Console.WriteLine(message);

            var result = JsonConvert.SerializeObject(new {error = ex.Message}, Formatting.None);

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtention
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}