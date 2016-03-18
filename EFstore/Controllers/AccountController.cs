using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFstore.Models;
using EFstore.ViewModels;
using System.Web.Security;
using EFstore.Filters;

namespace EFstore.Controllers
{
    public class AccountController : Controller
    {
        private AccDbContext db = new AccDbContext();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                //int userId = (from x in db.Users
                //                where x.Username == user.Username
                //                select x.UserID).SingleOrDefault();

                //if (userId > 0){
                //    // user exists
                //}
                //else {
                //    // user does not exist
                //}

                var user = db.Users.Where(u => u.Username == model.Username).FirstOrDefault();
                if (user == null)
                {
                    UserModel addUser = new UserModel();
                    addUser.Username = model.Username;
                    addUser.Password = model.Password;
                    addUser.UserRole = "RegularUser";
                    db.Users.Add(addUser);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = model.Username + " Successfully Registered.";
                }
                else
                {
                    ModelState.AddModelError("", "Username already exists");
                }             
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
           if (ModelState.IsValid)
           {
                var user = db.Users.Where(u => (u.Username == model.Username && u.Password == model.Password)).FirstOrDefault();
                if (user != null)
                {
                    //FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

                    var authTicket = new FormsAuthenticationTicket(
                    1,                             // version
                    model.Username,                      // user name
                    DateTime.Now,                  // created
                    DateTime.Now.AddMinutes(20),   // expires
                    model.RememberMe,                    // persistent?
                    user.UserRole
                    //"Moderator;Admin"                        // can be used to store roles
                    );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authCookie);



                    return RedirectToAction("LoggedIn");
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
            }
            return View();
        }

        
        public ActionResult LoggedIn()
        {
            if (User.Identity.Name != null)
            {
                ViewBag.username = HttpContext.User.Identity.Name;
                return View();
            }
            return RedirectToAction("Login");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}