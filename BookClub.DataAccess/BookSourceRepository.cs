using System;
using System.Collections.Generic;
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
            return _context.BookSources.ToList();
        }

        public BookSource Get(int bookSourceId)
        {
            return _context.BookSources.Find(bookSourceId);
        }
    }
}
