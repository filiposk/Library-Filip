using LibraryWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LibraryWebApi.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult GetAllBooks()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/book/getall/books");
                response.EnsureSuccessStatusCode();
                List<BookModel> books = response.Content.ReadAsAsync<List<BookModel>>().Result;
                ViewBag.Title = "All Books";
                return View(books);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditBooks(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/book/GetBook?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            BookModel books = response.Content.ReadAsAsync<BookModel>().Result;
            ViewBag.Title = "All Books";
            return View(books);
        }
        //[HttpPost]  
        public ActionResult UpdateBooks(BookModel book)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/book/UpdateBook", book);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooks");
        }

        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/book/GetBook?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            BookModel books = response.Content.ReadAsAsync<BookModel>().Result;
            ViewBag.Title = "All Books";
            return View(books);
        }

        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(BookModel book)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/book/InsertBook", book);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooks");
        }
        public ActionResult DeleteBook(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/book/DeleteBook?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooks");
        }
    }
}