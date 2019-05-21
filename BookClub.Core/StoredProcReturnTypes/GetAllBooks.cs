using System;

namespace BookClub.Core.StoredProcReturnTypes
{
    /// <summary>
    /// Represents one row returned from the stored procedure _sp_GetAllBooks.
    /// </summary>
    public class GetAllBooks
    {
        public int BookId { get; set; }

        public int BookClubId { get; set; }

        public int GenreId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime? DateRead { get; set; }

        public string MainCharacters { get; set; }

        public string Notes { get; set; }
        public string BookClubName { get; set; }
        public string GoodReadLink { get; set; }

        public int Stars { get; set; }

        public string GenreDesc { get; set; }
    }
}
