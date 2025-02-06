using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Middlewares
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
            // Log the incoming request
            Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");

            // Call the next middleware in the pipeline
            await _next(context);

            // Log the outgoing response
            Console.WriteLine($"Outgoing Response: {context.Response.StatusCode}");
        }
    }
}


