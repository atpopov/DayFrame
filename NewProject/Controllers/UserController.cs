using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Model;

namespace NewProject.Controllers
{
    public class UserController : Controller
    {
        User loggedInUser = new User();
        // GET: User
        [HttpGet]
        public ActionResult Register(int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Register (User userModel)
        {
            using(UserContext context = new UserContext())
            {
                if(context.Users.Any(x=>x.Username ==userModel.Username))
                {
                    ViewBag.DuplicateMessage = "Акаунт с такъв Username вече съществува.";
                    return View("Register", userModel);
                }
                context.Users.Add(userModel);
                context.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Успешна регистрация!";
            return View("Register", new User());
        }




        [HttpGet]
        public ActionResult Login(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Login(User userModel)
        {
           // bool successfulLogin = false;
            using (UserContext context = new UserContext())
            {
                if(context.Users.Any(x => x.Username==userModel.Username && x.Password==userModel.Password))
                {
                    //successfulLogin = true;
                    loggedInUser = userModel;
                    TempData["Apr"] = loggedInUser;
                    ViewBag.SuccessLoginMessage = "Успешен вход!";
                    return View("~/Views/Apr/Home.cshtml");
                }
                else
                {
                    ViewBag.FailedLoginMessage = "Неправилно потребителско име или парола!";
                    return View("Login", new User());                 
                }
            }
        }
    }
}