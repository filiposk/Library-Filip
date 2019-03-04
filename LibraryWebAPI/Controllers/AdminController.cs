using LibraryWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LibraryWebApi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult GetAllAdmins()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/admin/getall/admins");
                response.EnsureSuccessStatusCode();
                List<AdminModel> admins = response.Content.ReadAsAsync<List<AdminModel>>().Result;
                ViewBag.Title = "All Admins";
                return View(admins);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditAdmins(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/admin/Admins?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            AdminModel admins = response.Content.ReadAsAsync<AdminModel>().Result;
            ViewBag.Title = "All Admins";
            return View(admins);
        }
        //[HttpPost]  
        public ActionResult UpdateAdmins(AdminModel admin)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/admin/UpdateAdmin", admin);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllAdmins");
        }

        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/admin/GetAdmin?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            AdminModel admins = response.Content.ReadAsAsync<AdminModel>().Result;
            ViewBag.Title = "All Admins";
            return View(admins);
        }

        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(AdminModel admin)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/admin/InsertAdmin", admin);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllAdmins");
        }
        public ActionResult DeleteAdmin(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/admin/DeleteAdmin?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllAdmins");
        }
    }
}