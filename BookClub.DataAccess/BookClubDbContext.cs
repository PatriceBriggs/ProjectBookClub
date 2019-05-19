using BookClub.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Core
{
    public class BookClubDbContext: DbContext
    {
        public BookClubDbContext(string connString)
        {
            // Set a null initializer so that EF doesn't try to create a new database.
            Database.SetInitializer<BookClubDbContext>(null);

            // Set the connection string..
            Database.Connection.ConnectionString = connString;
        }

        // Register entities in the DbContext by adding a DbSet<T> for each entity.
        public DbSet<Book> Books { get; set; }

        public DbSet<BookClub> BookClubs { get; set; }

        public DbSet<BookSource> BookSources { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
