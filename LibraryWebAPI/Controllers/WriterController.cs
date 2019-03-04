using LibraryWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LibraryWebApi.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        public ActionResult GetAllWriters()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/writer/getall/writers");
                response.EnsureSuccessStatusCode();
                List<WriterModel> writers = response.Content.ReadAsAsync<List<WriterModel>>().Result;
                ViewBag.Title = "All Writers";
                return View(writers);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditWriters(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/writer/GetWriters?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            WriterModel writers = response.Content.ReadAsAsync<WriterModel>().Result;
            ViewBag.Title = "All Writers";
            return View(writers);
        }
        //[HttpPost]  
        public ActionResult UpdateWriters(WriterModel writer)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/writer/UpdateWriter", writer);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllWriters");
        }

        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/writer/GetWriter?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            WriterModel writers = response.Content.ReadAsAsync<WriterModel>().Result;
            ViewBag.Title = "All Writers";
            return View(writers);
        }

        [HttpGet]
        public ActionResult CreateWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateWriter(WriterModel writer)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/writer/InsertWriter", writer);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllWriters");
        }
        public ActionResult DeleteWriter(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/writer/DeleteWriter?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllWriters");
        }
    }
}