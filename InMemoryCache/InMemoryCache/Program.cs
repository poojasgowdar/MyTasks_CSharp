using System;
using System.Diagnostics;
using System.Runtime.Caching;

namespace InMemoryCache
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectCache cache = MemoryCache.Default;

            //add cache
            cache.Add("CacheName", "Value1", null);
            cache.Add("CacheName2", 0, null);

            // create cache item policy
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60.0),

            };

            //add cache with cache item policy
            cache.Add("CacheName3", "Expires In A Minute", cacheItemPolicy);

            //add cache with CacheItem object
            var cacheItem = new CacheItem("fullName", "Vikas Lalwani");
            cache.Add(cacheItem, cacheItemPolicy);

            //get cache value and print
            Console.WriteLine("Full Name " + cache.Get("fullName"));

            //print all cache
            Console.WriteLine("All key-values");
            PrintAllCache(cache);

            //remove cache
            cache.Remove("CacheName");

            //update cache value, from 0 to 1
            cache.Set("CacheName2", 1, null);

            //print all cache key value again to check updates
            Console.WriteLine("All key-values after updates");
            PrintAllCache(cache);
        }

        public static void PrintAllCache(ObjectCache cache)
        {
            //loop through all key-value pairs and print them
            foreach (var item in cache)
            {
                Console.WriteLine("cache object key-value: " + item.Key + "-" + item.Value);
            }
        }
    }
}




//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add<ExecutionTimeFilter>();
//});
//using Microsoft.AspNetCore.Mvc.Filters;
//using System.Diagnostics;
//using Microsoft.Extensions.Logging;

//public class ExecutionTimeFilter : ActionFilterAttribute
//{
//    private readonly ILogger<ExecutionTimeFilter> _logger;
//    private Stopwatch _stopwatch;

//    public ExecutionTimeFilter(ILogger<ExecutionTimeFilter> logger)
//    {
//        _logger = logger;
//    }

//    public override void OnActionExecuting(ActionExecutingContext context)
//    {
//        // Start the stopwatch before the action executes
//        _stopwatch = Stopwatch.StartNew();
//        _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} started.");
//    }

//    public override void OnActionExecuted(ActionExecutedContext context)
//    {
//        // Stop the stopwatch after the action executes
//        _stopwatch.Stop();
//        _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} finished in {_stopwatch.ElapsedMilliseconds} ms.");
//    }
//}


//using Microsoft.AspNetCore.Mvc.Filters;
//using System.Diagnostics;
//using Microsoft.Extensions.Logging;

//public class ExecutionTimeFilter : ActionFilterAttribute
//{
//    private readonly ILogger<ExecutionTimeFilter> _logger;
//    private Stopwatch _stopwatch;

//    public ExecutionTimeFilter(ILogger<ExecutionTimeFilter> logger)
//    {
//        _logger = logger;
//    }

//    public override void OnActionExecuting(ActionExecutingContext context)
//    {
//        // Start the stopwatch before the action executes
//        _stopwatch = Stopwatch.StartNew();
//        _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} started.");
//    }

//    public override void OnActionExecuted(ActionExecutedContext context)
//    {
//        // Stop the stopwatch after the action executes
//        _stopwatch.Stop();
//        _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} finished in {_stopwatch.ElapsedMilliseconds} ms.");
//    }
//}


