using AutoMapper;
using EfClass.DataAccess.Repositories;
using EfClass.Models.DBModels;
using EfClass.Models.DBModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfClass.Managers
{
    public class BookManager : IBookManager
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public BookManager(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        /// <see cref="IBookManager.AddNewBook(BookDto)"/>
       
        public bool AddNewBook(BookDto book)
        {
            Book dbBook = _mapper.Map<Book>(book);
            return _bookRepository.AddBook(dbBook);
        }

        /// <see cref="IBookManager.GetAllBooks()"/>

        public IEnumerable<BookDto> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            var booksList = _mapper.Map<IEnumerable<BookDto>>(books);
            return booksList;
           
        }

        public BookDto GetBookDetails(int bookId)
        {
            var book = _bookRepository.GetBookDetails(bookId);
            return _mapper.Map<BookDto>(book);
        }

        public bool RemoveBook(int bookId)
        {
            return _bookRepository.DeleteBook(bookId);
        }

        public bool UpdateBook(BookDto book)
        {
            var dbBook = _mapper.Map<Book>(book);
            return _bookRepository.UpdateBook(dbBook);
        }
    }
}
