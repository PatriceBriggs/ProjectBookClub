using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClub.Core;

namespace BookClub.Core
{
    public class BookClubRepository
    {
        private BookClubDbContext _context;

        public BookClubRepository(BookClubDbContext context)
        {
            _context = context;
        }
        public List<BookClub> GetBookClubs()
        {
            return _context.BookClubs.ToList();
        }

        public BookClub Get(int bookClubId)
        {
            return _context.BookClubs.Find(bookClubId);
        }

        public List<BookClub> AddBookClub(BookClub newBookClub)
        {
            SqlParameter prmBookClubName = new SqlParameter("bookClubName", newBookClub.BookClubName);
            _context.Database.ExecuteSqlCommand("Insert Into BookClub(BookClubName) Values (" + prmBookClubName + ")");

            return _context.BookClubs.ToList();
        }

        //public void DeleteBookClub(int genreId)
        //{
        //    SqlParameter prmGenreId = new SqlParameter("genreId", genreId);
        //    _context.Database.ExecuteSqlCommand("Delete From Genres Where GenreId = " + prmGenreId);

        //    return;
        //}
    }
}
