using BookClub.Core;
using System;
using System.Collections.Generic;
using System.Data;
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

        public EditBook GetOneBook(int bookId)
        {
            SqlParameter prmBookId = new SqlParameter("bookId", bookId);
            return _context.Database
                .SqlQuery<EditBook>("_sp_GetOneBook @bookId", prmBookId)
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

        public void EditBook(EditBook editBook)
        {

            SqlParameter prmBookId = new SqlParameter("bookId", editBook.BookId);
            SqlParameter prmGenreId = new SqlParameter("genreId", editBook.GenreId == 0 ? (object)DBNull.Value : editBook.GenreId);
            SqlParameter prmTitle = new SqlParameter("title", editBook.Title);
            SqlParameter prmAuthor = new SqlParameter("author", editBook.Author == null ? (object)DBNull.Value : editBook.Author);
            SqlParameter prmDateRead = new SqlParameter("dateRead", editBook.DateRead == null ? (object)DBNull.Value : editBook.DateRead);
            SqlParameter prmMainCharacters = new SqlParameter("mainCharacters", editBook.MainCharacters == null ? (object)DBNull.Value : editBook.MainCharacters);
            SqlParameter prmNotes = new SqlParameter("notes", editBook.Notes == null ? (object)DBNull.Value : editBook.Notes);
            SqlParameter prmBookClubId = new SqlParameter("bookClubId", editBook.BookClubId == 0 ? (object)DBNull.Value : editBook.BookClubId);
            SqlParameter prmGoodReadLink = new SqlParameter("goodReadLink", editBook.GoodReadLink == null ? (object)DBNull.Value : editBook.GoodReadLink);
            SqlParameter prmStars = new SqlParameter("stars", editBook.Stars  == 0 ? (object)DBNull.Value : editBook.Stars);



            var result =  _context.Database
                .SqlQuery<object>("_sp_EditBook @bookId, @genreId, @title, @author, @DateRead, @mainCharacters, @notes, @bookClubId, @goodReadLink, @stars", 
                                              prmBookId, prmGenreId, prmTitle, prmAuthor, prmDateRead, prmMainCharacters, prmNotes, prmBookClubId, prmGoodReadLink, prmStars)
                .ToList();
            return;
   
        }

        public void AddBook(AddBook newBook)
        {
            SqlParameter prmGenreId = new SqlParameter("genreId", newBook.GenreId == 0 ? (object)DBNull.Value : newBook.GenreId);
            SqlParameter prmTitle = new SqlParameter("title", newBook.Title);
            SqlParameter prmAuthor = new SqlParameter("author", newBook.Author == null ? (object)DBNull.Value : newBook.Author);
            SqlParameter prmDateRead = new SqlParameter("dateRead", newBook.DateRead == null ? (object)DBNull.Value : newBook.DateRead);
            SqlParameter prmMainCharacters = new SqlParameter("mainCharacters", newBook.MainCharacters == null ? (object)DBNull.Value : newBook.MainCharacters);
            SqlParameter prmNotes = new SqlParameter("notes", newBook.Notes == null ? (object)DBNull.Value : newBook.Notes);
            SqlParameter prmBookClubId = new SqlParameter("bookClubId", newBook.BookClubId == 0 ? (object)DBNull.Value : newBook.BookClubId);
            SqlParameter prmGoodReadLink = new SqlParameter("goodReadLink", newBook.GoodReadLink == null ? (object)DBNull.Value : newBook.GoodReadLink);
            SqlParameter prmStars = new SqlParameter("stars", newBook.Stars == 0 ? (object)DBNull.Value : newBook.Stars);

            var result =  _context.Database
                .SqlQuery<object>("_sp_AddBook @genreId, @title, @author, @dateRead, @mainCharacters, @notes, @bookClubId, @goodReadLink, @stars",
                                              prmGenreId, prmTitle, prmAuthor, prmDateRead, prmMainCharacters, prmNotes, prmBookClubId, prmGoodReadLink, prmStars)
                .ToList();
            return;

        }
    }
}
