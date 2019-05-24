using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Core
{
    public class BookSource
    {
        public int BookSourceId { get; set; }

        [Required(ErrorMessage = "Please enter a source")]
        [Display(Name = "Book Source Name:")]
        public string BookSourceName { get; set; }

        [Display(Name = "Book Source Link:")]
        public string BookSourceLink { get; set; }


    }
}
