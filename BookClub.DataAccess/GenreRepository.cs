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
            return _context.Genres.ToList();
        }

        public Genre Get(int genreId)
        {
            return _context.Genres.Find(genreId);
        }

        public List<Genre> AddGenre(Genre newGenre)
        {
            SqlParameter prmGenreDesc = new SqlParameter("genreDesc", newGenre.GenreDesc);
            _context.Database.ExecuteSqlCommand("Insert Into Genres(GenreDesc) Values (" + prmGenreDesc + ")");

            return _context.Genres.ToList();
        }

        //public void DeleteGenre(int genreId)
        //{
        //    SqlParameter prmGenreId = new SqlParameter("genreId", genreId);
        //    _context.Database.ExecuteSqlCommand("Delete From Genres Where GenreId = " + prmGenreId);

        //    return;
        //}
    }
}
