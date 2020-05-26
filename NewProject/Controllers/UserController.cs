using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Data;
using Data.Model;

namespace NewProject.Controllers
{
    public class UserController : Controller
    {
        //Object that contains the current User
        User loggedInUser = new User();
        // GET: User


        //The GET Method for the Register Page
        [HttpGet]
        public ActionResult Register(int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }


        //The POST Method for the Register Page
        [HttpPost]
        public ActionResult Register (User userModel)
        {
            //Connecting and accessing the data in Database for the Registration process
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


        //The GET Method for the Login Page
        [HttpGet]
        public ActionResult Login(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }


        //The POST Method for the Login Page
        [HttpPost]
        public ActionResult Login(User userModel)
        {
            //Connecting and accessing the data in Database for the Login process
            using (UserContext context = new UserContext())
            {
                if(context.Users.Any(x => x.Username==userModel.Username && x.Password==userModel.Password))
                {
                    //successfulLogin = true;
                    var ddd = context.Users.Where(x => x.Username == userModel.Username && x.Password == userModel.Password);
                    loggedInUser = userModel;

                    //Methods for storing the data for the logged in User, so we can use it in the other Controllers
                    TempData["Apr"] = ddd.First();
                    TempData["Controller"] = ddd.First();
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