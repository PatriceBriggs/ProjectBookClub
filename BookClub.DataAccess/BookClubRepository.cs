using System;
using System.Collections.Generic;
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
    }
}
