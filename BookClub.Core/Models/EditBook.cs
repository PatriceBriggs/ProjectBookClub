using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Core
{
    public class EditBook
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
        public DateTime? DateRead { get; set; }
        [Display(Name = "Main Characters")]
        public string MainCharacters { get; set; }
        public string Notes { get; set; }
        public int BookClubId { get; set; }
        [Display(Name = "Book Club Name")]
        public string BookClubName { get; set; }
        public string GoodReadLink { get; set; }
        public int GenreId { get; set; }

        [Display(Name = "Genre")]
        public string GenreDesc { get; set; }
        public int Stars { get; set; }
        [Display(Name = "Book Club")]
        public List<BookClub> BookClubList { get; set; }
        [Display(Name = "Genre")]
        public List<Genre> GenreList { get; set; }
    }
}
