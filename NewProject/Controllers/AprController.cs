using Data.Data;
using Data.Model;
using Microsoft.JSInterop;
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
        static int UserId;
        public ActionResult Home()
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

        [HttpGet]
        public ActionResult Notes(int id=0)
        {
            User loggedIn = (User)TempData["Controller"];
            TempData["Controller"] = loggedIn;
            Notes notesModel = new Notes();

            return View(notesModel);
        }
        [HttpPost]
        public ActionResult Notes(Notes notesModel)
        {
            User loggedIn = (User)TempData["Controller"];
            TempData["Controller"] = loggedIn;
            notesModel.UserId = loggedIn.Id;
            using (NotesContext context = new NotesContext())
            {
                context.Notes.Add(notesModel);
                context.SaveChanges();
            }
            return View("Notes",new Notes());
        }

        [HttpGet]
        public ActionResult DeleteNote(int id)
        {
            using(NotesContext context = new NotesContext())
            {
                return View(context.Notes.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult DeleteNote(int id, string a)
        {
            using(NotesContext context = new NotesContext())
            {
                Notes note = context.Notes.Where(x => x.Id == id).FirstOrDefault();
                context.Notes.Remove(note);
                context.SaveChanges();
            }
            return RedirectToAction("Notes");
        }
    }
}