using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Core
{ 
    public class Genre
    {
        [Required(ErrorMessage = "Please select a genre.")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Display(Name = "Genre Name")]
        public string GenreDesc { get; set; }
    }
}
