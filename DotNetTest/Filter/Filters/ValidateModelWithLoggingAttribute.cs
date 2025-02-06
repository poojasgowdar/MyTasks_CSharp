using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter.Filters
{
    public class ValidateModelWithLoggingAttributeActionFilterAttribute
    {
        private readonly ILogger<ValidateModelWithLoggingAttribute> _logger;

        public ValidateModelWithLoggingAttribute(ILogger<ValidateModelWithLoggingAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {

                _logger.LogError("Model validation failed for {ActionName} at {Time}", context.ActionDescriptor.DisplayName, DateTime.Now);


                foreach (var error in context.ModelState.Values)
                {
                    foreach (var subError in error.Errors)
                    {
                        _logger.LogError("Validation Error: {ErrorMessage}", subError.ErrorMessage);
                    }
                }


                var errorResponse = new
                {
                    StatusCode = 400,
                    Message = "Your request contains validation errors. Please correct them and try again.",
                    Errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                };


            }
        }


    }
}
