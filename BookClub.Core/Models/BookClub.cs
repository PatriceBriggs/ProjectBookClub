using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Core
{
    public class BookClub
    {
        public int BookClubId { get; set; }
        [Display(Name = "Book Club Name")]
        public string BookClubName { get; set; }
    }
}
