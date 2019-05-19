using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookClub.Core;
using BookClub.Core.StoredProcReturnTypes;
using BookClub.Core;


namespace BookClub
{
    public class BookClubSL
    {
        private BookRepository _bookRepository;
        private BookSourceRepository _bookSourceRepository;
        private GenreRepository _genreRepository;


        public BookClubSL(string connString)
        {
            BookClubDbContext context = new BookClubDbContext(connString);
            _bookRepository = new BookRepository(context);
            _bookSourceRepository = new BookSourceRepository(context);
            _genreRepository = new GenreRepository(context);
        }

        public List<Book> GEtAllBooks()
        {
            List<Book> listOfBooks = new List<Book>();
            listOfBooks = _bookRepository.GetAllBooks();

            return listOfBooks;
        }

        public Book EditBook(int bookId)
        {
            Book editBook = new Book();
            editBook = _bookRepository.GetOneBook(bookId);

            return editBook;
        }


    }
}