using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Core
{
    public class Book
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
        public DateTime? DateRead { get; set; }
        public string MainCharacters { get; set; }
        public string Notes { get; set; }
        public int BookClubId { get; set; }
        public string BookClubName { get; set; }
        public string GoodReadLink { get; set; }
        public string GenreDesc { get; set; }
        public int Stars { get; set; }
    }
}
