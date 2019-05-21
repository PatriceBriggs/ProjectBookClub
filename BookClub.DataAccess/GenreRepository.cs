using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Core
{
    public class GenreRepository
    {
        private BookClubDbContext _context;

        public GenreRepository(BookClubDbContext context)
        {
            _context = context;
        }

        public List<Genre> GetGenres()
        {
            return _context.Database
                  .SqlQuery<Genre>("_sp_GetGenres")
                  .ToList();
        } 
    }
}
