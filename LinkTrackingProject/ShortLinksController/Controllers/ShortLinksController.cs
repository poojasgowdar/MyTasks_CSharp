using DTOs.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ShortLinksController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortLinksController : ControllerBase
    {
        private readonly ShortLinkService _shortLinkService;

        public ShortLinksController(ShortLinkService shortLinkService)
        {
            _shortLinkService = shortLinkService;
        }
        [HttpGet]
        public IActionResult GetAllShortLinks()
        {
            var shortLinks = _shortLinkService.GetAllShortLinks();
            if (!shortLinks.Any())
            {
                return NotFound(new { Message = "No short links found." });
            }
            return Ok(shortLinks);
        }

        [HttpPost("shorten")]
        public IActionResult CreateShortLink([FromBody] CreateShortLinkDTO request)
        {
            var shortLink = _shortLinkService.CreateShortLink(request);
            return CreatedAtAction(nameof(GetShortLink), new { shortCode = shortLink.ShortCode }, shortLink);
        }

        [HttpGet("{shortCode}")]
        public IActionResult GetShortLink(string shortCode)
        {
            var shortLink = _shortLinkService.GetShortLink(shortCode);
            if (shortLink == null)
                return  NotFound(new { Message = $"Short link with code '{shortCode}' not found." });
            return Ok(shortLink);
        }

        [HttpDelete("{shortCode}")]
        public IActionResult DeleteShortLink(string shortCode)
        {
            var isDeleted = _shortLinkService.DeleteShortLink(shortCode);
            if (!isDeleted)
            {
                return NotFound(new { Message = $"Short link with code '{shortCode}' not found." });
            }
            return Ok("ShortLink Deleted Successfully");
        }

    }
}
