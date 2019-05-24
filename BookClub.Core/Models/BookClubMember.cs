using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Core
{
    public class BookClubMember
    {
        public int MemberId { get; set; }
        public int BookClubId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public string HomeNumber { get; set; }
    }
}
