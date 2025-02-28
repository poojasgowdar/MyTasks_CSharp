using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ShortLinksController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly ClickLogService _clickLogService;

        public AnalyticsController(ClickLogService clickLogService)
        {
            _clickLogService = clickLogService;
        }

        // GET: /api/analytics/{shortCode}/browsers
        [HttpGet("{shortCode}/browsers")]
        public IActionResult GetBrowserStats(string shortCode)
        {
            var browserStats = _clickLogService.GetBrowserStatistics(shortCode);
            if (!browserStats.Any())
                return NotFound(new { Message = "No browser analytics found for this short link." });

            return Ok(browserStats);
        }
    }
}
