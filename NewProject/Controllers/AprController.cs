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
        [HttpGet]
        public ActionResult Notes()
        {
            User loggedIn = (User)TempData["Controller"];
            TempData["Controller"] = loggedIn;
            UserId = loggedIn.Id;
            
            return View();
        }
        [HttpPost]
        
        public ActionResult Notes(Notes note)
        {
            User loggedIn = (User)TempData["Controller"];
            TempData["Controller"] = loggedIn;
            UserId = loggedIn.Id;
            note.UserId = loggedIn.Id;
            using (NotesContext context = new NotesContext())
            {
                context.Notes.Add(note);
                context.SaveChanges();
            }
            return View("~/Views/Apr/Notes.cshtml");
        }
        [HttpGet]
        public ActionResult SaveNote()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveNote(string note)
        {
            Notes newNote = new Notes();
            newNote.Note = note;
            newNote.UserId = UserId;
            using(NotesContext context = new NotesContext())
            {
                context.Notes.Add(newNote);
                context.SaveChanges();
            }
            return Json(note,JsonRequestBehavior.AllowGet);
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
        public ActionResult NewNotes(int id=0)
        {
            User loggedIn = (User)TempData["Controller"];
            TempData["Controller"] = loggedIn;
            Notes notesModel = new Notes();

            return View(notesModel);
        }
        [HttpPost]
        public ActionResult NewNotes(Notes notesModel)
        {
            User loggedIn = (User)TempData["Controller"];
            TempData["Controller"] = loggedIn;
            notesModel.UserId = loggedIn.Id;
            using (NotesContext context = new NotesContext())
            {
                context.Notes.Add(notesModel);
                context.SaveChanges();
            }
            return View("NewNotes",new Notes());
        }
    }
}