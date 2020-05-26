using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Controllers
{
    public class HomeController : Controller
    {
        User loggedInUser = new User();

        //Method that displays the index Page
        public ActionResult Index()
        {
            return View();
        }

        //Method that displays the HomePage
        public ActionResult Home(User currentUser)
        {
           
            ViewBag.Message = "Your application home page.";
            loggedInUser = currentUser;
            return View();
        }

        //Method that displays the Cooking Page
        public ActionResult Cooking()
        {
            ViewBag.Message = "Cooking Page.";

            return View();
        }

        //Method that displays the Movie Page
        public ActionResult Kino()
        {
            ViewBag.Message = "Kino Page.";

            return View();
        }

        //Method that displays the Music Page
        public ActionResult Music()
        {
            ViewBag.Message = "Music Page.";

            return View();
        }
    }
}