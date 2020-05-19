using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewProject.Controllers
{

    public class AprController : Controller
    {
        // GET: ApprovedUser
        User loggedIn = new User();
        public ActionResult Home()
        {

            return View();
        }
        public ActionResult Notes()
        {
            return View();
        }

        public ActionResult Cooking()
        {
            
            return View();
        }

        public ActionResult Kino()
        {
            return View();
        }

        public ActionResult Music()
        {
            return View();
        }

        public ActionResult UserProfile()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            TempData["Apr"] = null;
            return View("~/Views/Home/Home.cshtml");
        }

    }
}