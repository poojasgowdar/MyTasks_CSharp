using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middlewares.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Incoming Request:{context.Request.Method} {context.Request.Path}");

            await _next(context);

            Console.WriteLine($"Outgoing Request:{context.Response.StatusCode}");
        }
    }
}
