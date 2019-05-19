using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using BookClub.Core;

namespace BookClub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);

            // get the list of books
            List<Book> listofBooks = service.GEtAllBooks();

            return View(listofBooks);
        }

        public ActionResult EditBook(int bookId)
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);
            Book editBook = service.EditBook(bookId);

            return View(editBook);
        }

        public ActionResult DeleteBook(int bookId)
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);
            service.DeleteBook(bookId);

            // get the list of books
            List<Book> listofBooks = service.GEtAllBooks();

            return View("Index", listofBooks);
        }

        public ActionResult AddBook()
        {
            return View();
        }
    }
}