using LibraryWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LibraryWebApi.Controllers
{
    public class BookCategoryController : Controller
    {
        // GET: BookCategory
        public ActionResult GetAllBooksCategory()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/book/getall/bookscategory");
                response.EnsureSuccessStatusCode();
                List<BookCategoryModel> bookscategory = response.Content.ReadAsAsync<List<BookCategoryModel>>().Result;
                ViewBag.Title = "All Books Category";
                return View(bookscategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditBooksCategory(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/book/GetBooksCategory?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            BookCategoryModel bookscategory = response.Content.ReadAsAsync<BookCategoryModel>().Result;
            ViewBag.Title = "All Book Categories";
            return View(bookscategory);
        }
        //[HttpPost]  
        public ActionResult UpdateBooksCategory(BookCategoryModel bookcategory)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/book/UpdateBookCategory", bookcategory);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooksCategory");
        }

        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/book/GetBookCategory?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            BookCategoryModel bookscategory = response.Content.ReadAsAsync<BookCategoryModel>().Result;
            ViewBag.Title = "All Books Category";
            return View(bookscategory);
        }

        [HttpGet]
        public ActionResult CreateBookCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBookCategory(BookCategoryModel bookscategory)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/book/InsertBookCategory", bookscategory);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooksCategory");
        }
        public ActionResult DeleteBookCategory(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/book/DeleteBookCategory?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooksCategory");
        }
    }
}