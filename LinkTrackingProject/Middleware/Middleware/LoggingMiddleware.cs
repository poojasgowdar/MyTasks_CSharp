using Entities.Entities;
using Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IClickLogRepository clickLogRepository)
        {
            var userAgent = context.Request.Headers["User-Agent"].ToString();
            var browser = ParseBrowserFromUserAgent(userAgent);

            var path = context.Request.Path.Value?.Trim('/');
            if (!string.IsNullOrEmpty(path))
            {
                var clickLog = new ClickLog
                {
                    ShortCode = path,
                    IPAddress = context.Connection.RemoteIpAddress?.ToString(),
                    Browser = browser,
                    VisitedAt = DateTime.UtcNow
                };

                clickLogRepository.AddClickLog(clickLog);
            }

            await _next(context);
        }

        private string ParseBrowserFromUserAgent(string userAgent)
        {
            if (userAgent.Contains("Edg")) return "Edge";
            if (userAgent.Contains("Chrome")) return "Chrome";
            if (userAgent.Contains("Firefox")) return "Firefox";
            if (userAgent.Contains("Safari")) return "Safari";
            return "Other";
        }
    }
}
