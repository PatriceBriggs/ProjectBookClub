using BookClub.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BookClub.Core
{
    public class BookRepository
    {
        private BookClubDbContext _context;

        public BookRepository(BookClubDbContext context)
        {
            _context = context;
        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetOneBook(int bookId)
        {
            SqlParameter prmBookId = new SqlParameter("bookId", bookId);
            return _context.Database
                .SqlQuery<Book>("_sp_GetOneBook @bookId", prmBookId)
                .FirstOrDefault();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Database
                .SqlQuery<Book>("_sp_GetAllBooks")
                .ToList();
        }

        public void DeleteBook(int bookId)
        {
            SqlParameter prmBookId = new SqlParameter("bookId", bookId);
            _context.Database.ExecuteSqlCommand("Delete From Books Where BookId = " + bookId);

            return;
        }

        public List<Book> EditBook(int bookId, Book editBook)
        {
            SqlParameter prmBookId = new SqlParameter("bookId", bookId);
            SqlParameter prmGenreId = new SqlParameter("genreId", editBook.GenreId);
            SqlParameter prmTitle = new SqlParameter("title", editBook.Title);
            SqlParameter prmAuthor = new SqlParameter("author", editBook.Author);
            SqlParameter prmDateRead = new SqlParameter("dateRead", editBook.DateRead);
            SqlParameter prmMainCharacters = new SqlParameter("mainCharacters", editBook.MainCharacters);
            SqlParameter prmNotes = new SqlParameter("notes", editBook.Notes);
            SqlParameter prmBookClubId = new SqlParameter("bookClubId", editBook.BookClubId);
            SqlParameter prmGoodReadLink = new SqlParameter("goodReadLink", editBook.GoodReadLink);
            SqlParameter prmStars = new SqlParameter("stars", editBook.Stars);
            return _context.Database
                .SqlQuery<Book>("_sp_EditBook @bookId, @genreId, @title, @author, @DateRead, @mainCharacters, @notes, @bookClubId, @goodReadLink, @stars", 
                                              prmBookId, prmGenreId, prmTitle, prmAuthor, prmDateRead, prmMainCharacters, prmNotes, prmBookClubId, prmGoodReadLink, prmStars)
                .ToList();
   
        }

        public void AddBook(Book editBook)
        {
            SqlParameter prmGenreId = new SqlParameter("genreId", editBook.GenreId);
            SqlParameter prmTitle = new SqlParameter("title", editBook.Title);
            SqlParameter prmAuthor = new SqlParameter("author", editBook.Author);
            SqlParameter prmDateRead = new SqlParameter("dateRead", editBook.DateRead);
            SqlParameter prmMainCharacters = new SqlParameter("mainCharacters", editBook.MainCharacters);
            SqlParameter prmNotes = new SqlParameter("notes", editBook.Notes);
            SqlParameter prmBookClubId = new SqlParameter("bookClubId", editBook.BookClubId);
            SqlParameter prmGoodReadLink = new SqlParameter("goodReadLink", editBook.GoodReadLink);
            SqlParameter prmStars = new SqlParameter("stars", editBook.Stars);
            var result =  _context.Database
                .SqlQuery<object>("_sp_AddBook @genreId, @title, @author, @dateRead, @mainCharacters, @notes, @bookClubId, @goodReadLink, @stars",
                                              prmGenreId, prmTitle, prmAuthor, prmDateRead, prmMainCharacters, prmNotes, prmBookClubId, prmGoodReadLink, prmStars)
                .ToList();
            return;

        }
    }
}
