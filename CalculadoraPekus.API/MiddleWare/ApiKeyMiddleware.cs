using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System;
using System.Reflection.PortableExecutable;

namespace CalculadoraPekus.API.MiddleWare
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyHeader = "apikey";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        {
            if (!context.Request.Headers.TryGetValue(ApiKeyHeader, out var receivedKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key não encontrada.");
                return;
            }

            var validKey = configuration["ApiSettings:ApiKey"];

            if (!validKey.Equals(receivedKey))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("API Key inválida.");
                return;
            }

            await _next(context);
        }
    }
}