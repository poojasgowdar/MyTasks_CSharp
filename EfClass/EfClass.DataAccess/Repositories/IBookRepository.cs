using EfClass.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.DataAccess.Repositories
{
    public interface IBookRepository
    {
        /// <summary>
        /// Add book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool AddBook(Book book);
        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool UpdateBook(Book book);
        /// <summary>
        /// It deletes a book from DB
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool DeleteBook(int book);
        /// <summary>
        /// Get all books from DB
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Book> GetAllBooks();
        /// <summary>
        /// Get a book details by Id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>

        public Book GetBookDetails(int bookId);
    }
}
