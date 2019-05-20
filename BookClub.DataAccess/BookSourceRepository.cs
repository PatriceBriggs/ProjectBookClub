using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Core
{
    public class BookSourceRepository
    {
        private BookClubDbContext _context;

        public BookSourceRepository(BookClubDbContext context)
        {
            _context = context;
        }
        public List<BookSource> GetBookSources()
        {
            return _context.Database
                   .SqlQuery<BookSource>("_sp_GetBookSources")
                 .ToList();
        }

        public BookSource GetOneBookSource(int bookSourceId)
        {
            return _context.BookSources.Find(bookSourceId);
        }
        public List<BookSource> AddBookSource(BookSource newBookSource)
        {
            SqlParameter prmBookSourceName = new SqlParameter("bookSourceName", newBookSource.BookSourceName);
            SqlParameter prmBookSourceLink = new SqlParameter("bookSourceLink", newBookSource.BookSourceLink);
            return _context.Database
                .SqlQuery<BookSource>("_sp_AddBookSource", prmBookSourceName, prmBookSourceLink)
                .ToList();
        }

        public List<BookSource> EditBookSource(int bookSourceId, BookSource editBookSource)
        {
            SqlParameter prmBookSourceId = new SqlParameter("bookSourceId", bookSourceId);
            SqlParameter prmBookSourceName = new SqlParameter("bookSourceName", editBookSource.BookSourceName);
            SqlParameter prmBookSourceLink = new SqlParameter("bookSourceLink", editBookSource.BookSourceLink);
            return _context.Database
                .SqlQuery<BookSource>("_sp_EditBookSource", prmBookSourceId, prmBookSourceName, prmBookSourceLink)
                .ToList();

        }

        public void DeleteBookSource(int bookSourceId)
        {
            SqlParameter prmBookId = new SqlParameter("bookSourceId", bookSourceId);
            _context.Database.ExecuteSqlCommand("Delete From BooksSources Where BookSourceId = " + bookSourceId);

            return;
        }

    }
}
