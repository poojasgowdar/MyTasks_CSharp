using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Log before the action executes
            _logger.LogInformation("Executing action {ActionName} at {Time}", context.ActionDescriptor.DisplayName, DateTime.UtcNow);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Log after the action executes
            _logger.LogInformation("Executed action {ActionName} at {Time}", context.ActionDescriptor.DisplayName, DateTime.UtcNow);
        }
    }
}
