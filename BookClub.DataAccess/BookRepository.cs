using Aspose.Cells;
using BookClub.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BookClub.Core
{
    public class BookRepository
    {
        private BookClubDbContext _context;

        public BookRepository(BookClubDbContext context)
        {
            _context = context;
        }

        public EditBook GetOneBook(int bookId)
        {
            SqlParameter prmBookId = new SqlParameter("bookId", bookId);
            return _context.Database
                .SqlQuery<EditBook>("_sp_GetOneBook @bookId", prmBookId)
                .FirstOrDefault();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Database
                .SqlQuery<Book>("_sp_GetAllBooks")
                .ToList();
        }

        public void DeleteBook(int bookId)
        {
            SqlParameter prmBookId = new SqlParameter("bookId", bookId);
            _context.Database.ExecuteSqlCommand("Delete From Books Where BookId = " + bookId);

            return;
        }

        public void EditBook(EditBook editBook)
        {

            SqlParameter prmBookId = new SqlParameter("bookId", editBook.BookId);
            SqlParameter prmGenreId = new SqlParameter("genreId", editBook.GenreId == 0 ? (object)DBNull.Value : editBook.GenreId);
            SqlParameter prmTitle = new SqlParameter("title", editBook.Title);
            SqlParameter prmAuthor = new SqlParameter("author", editBook.Author == null ? (object)DBNull.Value : editBook.Author);
            SqlParameter prmDateRead = new SqlParameter("dateRead", editBook.DateRead == null ? (object)DBNull.Value : editBook.DateRead);
            SqlParameter prmMainCharacters = new SqlParameter("mainCharacters", editBook.MainCharacters == null ? (object)DBNull.Value : editBook.MainCharacters);
            SqlParameter prmNotes = new SqlParameter("notes", editBook.Notes == null ? (object)DBNull.Value : editBook.Notes);
            SqlParameter prmBookClubId = new SqlParameter("bookClubId", editBook.BookClubId == 0 ? (object)DBNull.Value : editBook.BookClubId);
            SqlParameter prmGoodReadLink = new SqlParameter("goodReadLink", editBook.GoodReadLink == null ? (object)DBNull.Value : editBook.GoodReadLink);
            SqlParameter prmStars = new SqlParameter("stars", editBook.Stars  == 0 ? (object)DBNull.Value : editBook.Stars);

            var result =  _context.Database
                .SqlQuery<object>("_sp_EditBook @bookId, @genreId, @title, @author, @DateRead, @mainCharacters, @notes, @bookClubId, @goodReadLink, @stars", 
                                              prmBookId, prmGenreId, prmTitle, prmAuthor, prmDateRead, prmMainCharacters, prmNotes, prmBookClubId, prmGoodReadLink, prmStars)
                .ToList();
            return;
   
        }

        public Workbook GetAllBooksExcel()
        {
            //Instantiate License class and call its SetLicense method to use the license
            string licPath = @"C:\ProjectBookClub\Aspose.Total.lic";
            Aspose.Cells.License lic = new Aspose.Cells.License();
            lic.SetLicense(licPath);

            DataSet dataset = new DataSet();

            string bkConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(bkConn))
            {
                SqlCommand cmd = new SqlCommand("_sp_GetAllBooksExcel", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                //DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataset);
            }

            DataTable books = dataset.Tables[0];
            Workbook workBook = new Workbook();
            workBook.Worksheets.Clear();

            // Format the header row
            Worksheet workSheet = workBook.Worksheets.Add("Books");
            workSheet.Cells.ImportDataTable(books, true, "A1");

            Aspose.Cells.Range range = workSheet.Cells.CreateRange("A1","I1");
            Aspose.Cells.Style headerStyle = workBook.CreateStyle();
            headerStyle.Font.Name = "Calibri";
            headerStyle.Font.IsBold = true;
            headerStyle.Font.Size = 13;

            StyleFlag flg = new StyleFlag();
            flg.Font = true;

            range.ApplyStyle(headerStyle, flg);

            //Format font for the rest of the sheet

            Aspose.Cells.Range range1 = workSheet.Cells.CreateRange("A2", "I100");
            Aspose.Cells.Style style1 = workBook.CreateStyle();
            style1.Font.Name = "Calibri";
            style1.Font.Size = 12;

            StyleFlag flg1 = new StyleFlag();
            flg1.Font = true;

            range1.ApplyStyle(style1, flg);
            // Title
            workSheet.Cells.SetColumnWidth(0, 40);
            // Author
            workSheet.Cells.SetColumnWidth(1, 25);
            // Date Read - set date format for this column         
            Aspose.Cells.Style style = workBook.CreateStyle();
            style.Number = 14;
            StyleFlag flag = new StyleFlag();
            flag.NumberFormat = true;
            //workSheet.Cells.SetColumnWidth(7, 16);
            //workSheet.Cells.Columns[7].ApplyStyle(style, flag);
            workSheet.Cells.SetColumnWidth(2, 12);
            workSheet.Cells.Columns[2].ApplyStyle(style, flag);
            // Main Characters
            workSheet.Cells.SetColumnWidth(3, 40);
            // Notes
            workSheet.Cells.SetColumnWidth(4, 40);
            // Book Club
            workSheet.Cells.SetColumnWidth(5, 20);
            // Book Information
            workSheet.Cells.SetColumnWidth(6, 40);
            // Stars
            workSheet.Cells.SetColumnWidth(7, 15);
            // Genre
            workSheet.Cells.SetColumnWidth(8, 15);

            return workBook;
        }

        public void AddBook(AddBook newBook)
        {
            SqlParameter prmGenreId = new SqlParameter("genreId", newBook.GenreId == 0 ? (object)DBNull.Value : newBook.GenreId);
            SqlParameter prmTitle = new SqlParameter("title", newBook.Title);
            SqlParameter prmAuthor = new SqlParameter("author", newBook.Author == null ? (object)DBNull.Value : newBook.Author);
            SqlParameter prmDateRead = new SqlParameter("dateRead", newBook.DateRead == null ? (object)DBNull.Value : newBook.DateRead);
            SqlParameter prmMainCharacters = new SqlParameter("mainCharacters", newBook.MainCharacters == null ? (object)DBNull.Value : newBook.MainCharacters);
            SqlParameter prmNotes = new SqlParameter("notes", newBook.Notes == null ? (object)DBNull.Value : newBook.Notes);
            SqlParameter prmBookClubId = new SqlParameter("bookClubId", newBook.BookClubId == 0 ? (object)DBNull.Value : newBook.BookClubId);
            SqlParameter prmGoodReadLink = new SqlParameter("goodReadLink", newBook.GoodReadLink == null ? (object)DBNull.Value : newBook.GoodReadLink);
            SqlParameter prmStars = new SqlParameter("stars", newBook.Stars);

            var result =  _context.Database
                .SqlQuery<object>("_sp_AddBook @genreId, @title, @author, @dateRead, @mainCharacters, @notes, @bookClubId, @goodReadLink, @stars",
                                              prmGenreId, prmTitle, prmAuthor, prmDateRead, prmMainCharacters, prmNotes, prmBookClubId, prmGoodReadLink, prmStars)
                .ToList();
            return;

        }
    }
}
