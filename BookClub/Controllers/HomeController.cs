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
            List<Book> listofBooks = service.GetAllBooks();

            return View(listofBooks);
        }

        public ActionResult EditBook(int bookId)
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);
            EditBook editBook = service.EditBook(bookId);

            // get list of book clubs and add to model
            editBook = service.GetBookClubs(editBook);

            // get list of genres and add to model
            editBook = service.GetGenres(editBook);

            return View(editBook);
        }

        [HttpPost]
        public ActionResult EditBook(EditBook editBook)
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);
            if (ModelState.IsValid)
            {

                service.EditBook(editBook);

                // get the list of books
                List<Book> listOfBooks = service.GetAllBooks();
                return View("Index", listOfBooks);
            }
            else
            {
                // get list of book clubs and add to model
                editBook = service.GetBookClubs(editBook);

                // get list of genres and add to model
                editBook = service.GetGenres(editBook);

                return View(editBook);
            }
        }

        public ActionResult DeleteBook(int bookId)
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);
            service.DeleteBook(bookId);

            // get the list of books
            List<Book> listofBooks = service.GetAllBooks();

            return View("Index", listofBooks);
        }

        [HttpPost]
        public ActionResult AddBook(AddBook newBook)
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);
            if (ModelState.IsValid)
            { 
                service.AddBook(newBook);

                // get the list of books
                List<Book> listOfBooks = service.GetAllBooks();
                return View("Index", listOfBooks);
            }
            else
            {
                // get list of book clubs and add to model
                newBook = service.GetBookClubs(newBook);

                // get list of genres and add to model
                newBook = service.GetGenres(newBook);

                return View(newBook);
            }
        }

        public ActionResult AddBook()
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);

            AddBook addBook = new AddBook();

            // get list of book clubs and add to model
            addBook = service.GetBookClubs(addBook);

            // get list of genres and add to model
            addBook = service.GetGenres(addBook);

            return View(addBook);
        }
        public ActionResult GetBookSources()
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);
            List<BookSource> bookSources = new List<BookSource>();
            bookSources = service.GetBookSources();
            return View("BookSources", bookSources);
        }


        [HttpPost]
        public ActionResult AddBookSource(string newBookSourceName, string newBookSourceLink)
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);

            BookSource newBookSource = new BookSource();
            newBookSource.BookSourceName = newBookSourceName;
            newBookSource.BookSourceLink = newBookSourceLink;
            service.AddBookSource(newBookSource);

            return RedirectToAction("GetBookSources", "Home");

        }

        public ActionResult GetGenres()
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);
            List<Genre> genreList = new List<Genre>();
            genreList = service.GetGenres();
            return View("Genres",genreList);
        }

        public ActionResult GetBookClubs()
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);
            List<BookClub.Core.BookClub> listBookClubs = new List<BookClub.Core.BookClub>();
            listBookClubs = service.GetBookClubs();
            return View("BookClubs", listBookClubs);
        }
        public ActionResult AddBookClub(string newBookClubName)
        {
            string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
            BookClubSL service = new BookClubSL(connString);

            service.AddBookClub(newBookClubName);
            return RedirectToAction("GetBookClubs", "Home");

        }
    }
}