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
        public void AddBookSource(BookSource newBookSource)
        {
            SqlParameter prmBookSourceName = new SqlParameter("bookSourceName", newBookSource.BookSourceName);
            SqlParameter prmBookSourceLink = new SqlParameter("bookSourceLink", newBookSource.BookSourceLink);
            var result = _context.Database
                .SqlQuery<object>("_sp_AddBookSource @bookSourceName, @bookSourceLink",
                                  prmBookSourceName, prmBookSourceLink)
                .ToList();
            return;
            
        }

        public void EditBookSource(int bookSourceId, string editBookSourceName, string editBookSourceLink)
        {
            SqlParameter prmBookSourceId = new SqlParameter("bookSourceId", bookSourceId);
            SqlParameter prmBookSourceName = new SqlParameter("editBookSourceName", editBookSourceName);
            SqlParameter prmBookSourceLink = new SqlParameter("editBookSourceLink", editBookSourceLink);
            _context.Database
                .SqlQuery<object>("_sp_EditBookSource @bookSourceId, @editBookSourceName, @editBookSourceLink",
                                    prmBookSourceId, prmBookSourceName, prmBookSourceLink)
                .ToList();
            return;    

        }

        public void DeleteBookSource(int bookSourceId)
        {
            SqlParameter prmBookId = new SqlParameter("bookSourceId", bookSourceId);
            _context.Database.ExecuteSqlCommand("Delete From BookSources Where BookSourceId = " + bookSourceId);

            return;
        }

    }
}
