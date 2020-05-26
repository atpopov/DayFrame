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

        //Method that displays the HomePage for a logged in User
        public ActionResult Home()
        {

            return View();
        }

        //Method that displays the Cooking Page for a logged in User
        public ActionResult Cooking()
        {
            
            return View();
        }

        //Method that displays the Movie Page for a logged in User
        public ActionResult Kino()
        {
            return View();
        }


        //Method that displays the Music Page for a logged in User
        public ActionResult Music()
        {
            return View();
        }

        //The GET Method that displays the Personal User Profile
        [HttpGet]
        public ActionResult UserProfile(int id = 0)
        {
            //Declaring an object that contains the current User
            User loggedIn = (User)TempData["Controller"];

            TempData["Controller"] = loggedIn;

            return View(loggedIn);
        }

        //The POST Method that posts the Update for the Personal User Profile
        [HttpPost]
        public ActionResult UserProfile(string name)
        {
            //Declaring an object that contains the current User
            User loggedIn = (User)TempData["Controller"];

            TempData["Controller"] = loggedIn;

            //Connecting and accessing the data in Database to update the Personal Data
            using (UserContext context = new UserContext())
            {
                var UserInList = context.Users.Where(x => x.Id == loggedIn.Id).FirstOrDefault();
                context.Users.Where(x => x.Id == loggedIn.Id).FirstOrDefault().Name = name;
                context.SaveChanges();
            }
            return View();
        }

        //Method for Signing out from a profile
        public ActionResult SignOut()
        {
            TempData["Apr"] = null;
            return View("~/Views/Home/Home.cshtml");
        }


        //The GET Method for the Notes Page
        [HttpGet]
        public ActionResult Notes(int id=0)
        {
            User loggedIn = (User)TempData["Controller"];
            TempData["Controller"] = loggedIn;
            Notes notesModel = new Notes();

            return View(notesModel);
        }

        //The POST Method that creates the new Notes and stores them into the Database
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


        //The GET Method for a Note Removal
        [HttpGet]
        public ActionResult DeleteNote(int id)
        {
            using(NotesContext context = new NotesContext())
            {
                return View(context.Notes.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        //The POST Method that removes the Note from the Database
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