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

        public void AddBookClub(string newBookClubName)
        {
            //SqlParameter prmBookClubName = new SqlParameter("bookClubName", newBookClubName);
            _context.Database.ExecuteSqlCommand("Insert Into BookClubs(BookClubName) Values ('" + newBookClubName + "')");
            return;
        }  

        public void EditBookClub(int bookClubId, string editBookClubName)
        {
            _context.Database.ExecuteSqlCommand("Update BookClubs Set BookClubName = '" + editBookClubName + "' WHERE BookClubId = " + bookClubId);

            return;
        }

        public BookClub GetOneBookClub(int bookClubId)
        {
            return _context.BookClubs.Find(bookClubId);

        }
    }
}
