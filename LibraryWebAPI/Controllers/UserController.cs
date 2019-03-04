using LibraryWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LibraryWebApi.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult GetAllUsers()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/user/getall/users");
                response.EnsureSuccessStatusCode();
                List<UserModel> users = response.Content.ReadAsAsync<List<UserModel>>().Result;
                ViewBag.Title = "All Users";
                return View(users);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditUsers(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/user/Users?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            UserModel users = response.Content.ReadAsAsync<UserModel>().Result;
            ViewBag.Title = "All Users";
            return View(users);
        }
        //[HttpPost]  
        public ActionResult UpdateUsers(UserModel user)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/user/UpdateUser", user);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllUsers");
        }

        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/user/GetUser?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            UserModel users = response.Content.ReadAsAsync<UserModel>().Result;
            ViewBag.Title = "All Users";
            return View(users);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(UserModel user)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/user/InsertUser", user);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllUsers");
        }
        public ActionResult DeleteUser(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/user/DeleteUser?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllUsers");
        }
    }
}