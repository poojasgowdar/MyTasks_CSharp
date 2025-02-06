using AutoMapper;
using EFCoreManyToMany.Database;
using EFCoreManyToMany.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCoreManyToMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        public BookDbContext _context;
        private readonly IMapper _mapper;
        public BooksController(BookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //GET:api/Books
        [HttpGet]
        public IActionResult Get()
        {
            List<BookDto> bookDtos = new List<BookDto>();
            //using (var context = new BookDbContext())
            //{
            //    var books = context.Books.ToList();
            //    return Ok(books);
            //}
            var books = _context.Books.Include(x => x.Author).ToList();
            _mapper.Map(books, bookDtos);
            //foreach(var book in books)
            //{
            //    bookDtos.Add(new BookDto
            //    {
            //        BookId = book.BookId,
            //        Title = book.Title,
            //        AuthorName = book.Author.AuthorName
            //    });
            //}
            return Ok(bookDtos);
            // return Ok();

        }
        //Post:api/Books
        [HttpPost]
        public IActionResult Post([FromBody] BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok();
        }

        // PUT: api/Books/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookDto bookDto)
        {

             // Find the book in the database
            var existingBook = _context.Books.Find(id);
            _mapper.Map(bookDto, existingBook);
             // Save changes
            _context.SaveChanges();

            return NoContent(); // Success without returning data
        }
        //DELETE: api/Books/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            // Find the book in the database
            var existingBook = _context.Books.Find(id);
           
            // Save changes
            _context.Books.Remove(existingBook);
            _context.SaveChanges();

            return NoContent(); // Success without returning data
        }

        //GET SingleBook
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _context.Books.Find(id);
            //if (book == null)
            //{
            //    return NotFound();
            //}

            var bookDtos = _mapper.Map<BookDto>(book);
            return Ok(bookDtos);
        }

    }
}
