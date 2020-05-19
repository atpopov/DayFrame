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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home(User currentUser)
        {
           
            ViewBag.Message = "Your application description page.";
            loggedInUser = currentUser;
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Cooking()
        {
            ViewBag.Message = "Cooking Page.";

            return View();
        }

        public ActionResult Kino()
        {
            ViewBag.Message = "Kino Page.";

            return View();
        }

        public ActionResult Music()
        {
            ViewBag.Message = "Music Page.";

            return View();
        }

        public ActionResult Notes()
        {
            ViewBag.Message = "Notes";

            return View();
        }
    }
}