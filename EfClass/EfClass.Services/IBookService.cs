using EfClass.Models.DBModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.Services
{
    public interface IBookService
    {
        /// <summary>
        /// Add a new Book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool AddNewBook(BookDto book);
        /// <summary>
        /// Remove book based on Id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>true/false</returns>

        public bool RemoveBook(int bookId);
        /// <summary>
        /// Get all books in DB
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BookDto> GetAllBooks();
        /// <summary>
        /// Get book Details
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public BookDto GetBookDetails(int bookId);
        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>

        public bool UpdateBook(BookDto book);
    }
}
