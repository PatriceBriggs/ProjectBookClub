using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Aspose.Cells;
using BookClub.Core;
using BookClub.Core.StoredProcReturnTypes;

namespace BookClub
{
    public class BookClubSL
    {
        private BookRepository _bookRepository;
        private BookSourceRepository _bookSourceRepository;
        private GenreRepository _genreRepository;
        private BookClubRepository _bookClubRepository;

        public BookClubSL(string connString)
        {
            BookClubDbContext context = new BookClubDbContext(connString);

            _bookRepository = new BookRepository(context);
            _bookSourceRepository = new BookSourceRepository(context);
            _genreRepository = new GenreRepository(context);
            _bookClubRepository = new BookClubRepository(context);
        }

        public List<Book> GetAllBooks()
        {
            List<Book> listOfBooks = new List<Book>();
            listOfBooks = _bookRepository.GetAllBooks();

            return listOfBooks;
        }

        public EditBook EditBook(int bookId)
        {
            EditBook editBook = new EditBook();
            editBook = _bookRepository.GetOneBook(bookId);

            return editBook;
        }
        internal void EditBook(EditBook editBook)
        {
            _bookRepository.EditBook(editBook);
        }

        public void DeleteBook(int bookId)
        {
            _bookRepository.DeleteBook(bookId);
            return;
        }

        internal void AddBook(AddBook newBook)
        {
             _bookRepository.AddBook(newBook);
             return;
        }

        internal Workbook GetAllBooksExcel()
        {
            Workbook workBook = new Workbook();

            workBook = _bookRepository.GetAllBooksExcel();
            return workBook;
        }

        internal AddBook GetBookClubs(AddBook addBook)
        {           
            List<BookClub.Core.BookClub> bookClubList = new List<BookClub.Core.BookClub>();
            bookClubList = _bookClubRepository.GetBookClubs();

            // add the genreList to the addBook model
            addBook.BookClubList = bookClubList;

            return addBook;
        }

        internal List<BookClub.Core.BookClub> GetBookClubs()
        {
            return _bookClubRepository.GetBookClubs();
        }

        internal EditBook GetBookClubs(EditBook editBook)
        {
            List<BookClub.Core.BookClub> bookClubList = new List<BookClub.Core.BookClub>();
            bookClubList = _bookClubRepository.GetBookClubs();

            // add the genreList to the addBook model
            editBook.BookClubList = bookClubList;

            return editBook;
        }

        internal AddBook GetGenres(AddBook addBook)
        {
            List<Genre> genreList = new List<Genre>();
            genreList = _genreRepository.GetGenres();

            // add the genreList to the addBook model
            addBook.GenreList = genreList;

            return addBook;
        }

        internal EditBook GetGenres(EditBook editBook)
        {
            List<Genre> genreList = new List<Genre>();
            genreList = _genreRepository.GetGenres();

            // add the genreList to the addBook model
            editBook.GenreList = genreList;

            return editBook;
        }

        internal List<Genre> GetGenres()
        {
            return _genreRepository.GetGenres();
        }

        internal List<BookSource> GetBookSources()
        {
            return _bookSourceRepository.GetBookSources();
        }

        internal void AddBookSource(BookSource newBookSource)
        {
            _bookSourceRepository.AddBookSource(newBookSource);
            return;
        }

        internal void DeleteBookSource(int bookSourceId)
        {
            _bookSourceRepository.DeleteBookSource(bookSourceId);
            return;
        }

        internal void AddBookClub(string newBookClubName)
        {
            _bookClubRepository.AddBookClub(newBookClubName);
            return;
        }
    }
}