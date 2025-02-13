namespace Product_MVC_Project.Middlewares
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
            Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");
            await _next(context);
            Console.WriteLine($"Outgoing Request: {context.Response.StatusCode}");
        }
    }
}
