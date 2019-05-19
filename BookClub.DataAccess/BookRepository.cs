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
    }
}
