using EfClass.Managers;
using EfClass.Models.DBModels;
using EfClass.Models.DBModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.Services
{
    public class BookService : IBookService
    {

        private readonly IBookManager _bookManager;
        //logger 
        public BookService(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        bool IBookService.AddNewBook(BookDto book)
        {
            return _bookManager.AddNewBook(book);
        }

        IEnumerable<BookDto> IBookService.GetAllBooks()
        {
            return _bookManager.GetAllBooks();
        }

        BookDto IBookService.GetBookDetails(int bookId)
        {
            return _bookManager.GetBookDetails(bookId);
        }

        bool IBookService.RemoveBook(int bookId)
        {
            return _bookManager.RemoveBook(bookId);
        }

        public bool UpdateBook(BookDto book)
        {
            return _bookManager.UpdateBook(book);
        }
    }
}
