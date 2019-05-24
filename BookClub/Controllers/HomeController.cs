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
        private static string connString = WebConfigurationManager.ConnectionStrings["BookClubConnString"].ConnectionString;
        public BookClubSL service = new BookClubSL(connString);
        public ActionResult Index()
        {
            // get the list of books
            List<Book> listofBooks = service.GetAllBooks();

            return View(listofBooks);
        }

        public ActionResult EditBook(int bookId)
        {
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
            service.DeleteBook(bookId);

            // get the list of books
            List<Book> listofBooks = service.GetAllBooks();

            return View("Index", listofBooks);
        }

        [HttpPost]
        public ActionResult AddBook(AddBook newBook)
        {
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
            AddBook addBook = new AddBook();

            // get list of book clubs and add to model
            addBook = service.GetBookClubs(addBook);

            // get list of genres and add to model
            addBook = service.GetGenres(addBook);

            return View(addBook);
        }
        public ActionResult GetBookSources()
        {
            List<BookSource> bookSources = new List<BookSource>();
            bookSources = service.GetBookSources();
            return View("BookSources", bookSources);
        }


        [HttpPost]
        public ActionResult AddBookSource(string newBookSourceName, string newBookSourceLink)
        {
            BookSource newBookSource = new BookSource();
            newBookSource.BookSourceName = newBookSourceName;
            newBookSource.BookSourceLink = newBookSourceLink;
            service.AddBookSource(newBookSource);

            return RedirectToAction("GetBookSources", "Home");

        }

        public ActionResult EditBookSource(int bookSourceId)
        {
            BookSource editBookSource = new BookSource();
            editBookSource = service.GetOneBookSource(bookSourceId);
            //List<BookSource> editOneBookSource = new List<BookSource>();
            //editOneBookSource.Add(editBookSource);
            return View("EditBookSource", editBookSource);
        }
        [HttpPost]
        public ActionResult EditBookSource(int bookSourceId, string editBookSourceName, string editBookSourceLink)
        {
            service.EditBookSource(bookSourceId, editBookSourceName, editBookSourceLink);

            return RedirectToAction("GetBookSources", "Home");
        }

        public ActionResult GetGenres()
        {
            List<Genre> genreList = new List<Genre>();
            genreList = service.GetGenres();
            return View("Genres",genreList);
        }

        public ActionResult GetBookClubs()
        {
            List<BookClub.Core.BookClub> listBookClubs = new List<BookClub.Core.BookClub>();
            listBookClubs = service.GetBookClubs();
            return View("BookClubs", listBookClubs);
        }
        public ActionResult AddBookClub(string newBookClubName)
        {
            service.AddBookClub(newBookClubName);
            return RedirectToAction("GetBookClubs", "Home");

        }
        public ActionResult DeleteBookSource(int bookSourceId)
        {
            service.DeleteBookSource(bookSourceId);

            return RedirectToAction("GetBookSources", "Home");
        }
        public ActionResult EditBookClub(int bookClubId)
        {
            return View();
        }
    }
}