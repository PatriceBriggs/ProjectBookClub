using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class ExcelExportController : Controller
    {
       // private Aspose.Cells.License _licenseCells;
        private static string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
        public BookClubSL service = new BookClubSL(connString);
        // GET: ExcelExport
        public ActionResult ExportAllBooks()
        {

            //Instantiate License class and call its SetLicense method to use the license
            //Aspose.Cells.License license = new Aspose.Cells.License();
            //license.SetLicense("Aspose.Total.lic");

            byte[] wbBytes;

            Workbook workbook = service.GetAllBooksExcel();
            // set up filename
            string today = DateTime.Now.ToString("MM_dd_yyyy");
            string tempFileName = String.Format("BooksRead_" + today + ".xlsx");

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Save(ms, SaveFormat.Xlsx);
                wbBytes = ms.ToArray();

                Response.AddHeader("content-disposition", "attachment; filename=" + tempFileName);
            }
            return File(wbBytes, "application/vnd.ms-excel");

        }
    }
}