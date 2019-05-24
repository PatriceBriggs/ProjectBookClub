using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Core
{
    public class Book
    {
        public int BookId { get; set; }
        public int SelectedGenreId { get; set; }

        [Required(ErrorMessage = "Please enter the title.")]
        public string Title { get; set; }
        [Required()]
        public string Author { get; set; }

        [Display(Name = "Date Read")]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime? DateRead { get; set; }
        public string MainCharacters { get; set; }
        public string Notes { get; set; }
        public int SelectedBookClubId { get; set; }
        public string BookClubName { get; set; }
        public string GoodReadLink { get; set; }
        public string GenreDesc { get; set; }
        public int Stars { get; set; }
    }
}
