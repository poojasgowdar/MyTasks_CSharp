using DataAccessLayer.Models;
using LibraryManagement.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryManagementController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public LibraryManagementController(LibraryDbContext context)
        {
            _context = context;
        }
        [HttpGet("books")]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _context.Books.Include(b => b.Genre).ToList();
            return Ok(books);
        }
        [HttpGet("genres")]
        public ActionResult<IEnumerable<Genre>> GetGenres()
        {
            var genres = _context.Genres.ToList();
            return Ok(genres);
        }

    }
}
