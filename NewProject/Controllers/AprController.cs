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

        //The GET Method that displays the Cooking Page for a logged in User
        [HttpGet]
        public ActionResult Cooking(int id = 0)
        {
            Cook cookModel = new Cook();

            return View(cookModel);
        }

        //The POST Method that creates the new Cook Model and stores them into the Database
        [HttpPost]
        public ActionResult Cooking(Cook cookModel)
        {
            using (CookContext context = new CookContext())
            {
                context.CookComments.Add(cookModel);
                context.SaveChanges();
            }
            return View("Cooking", new Cook());
        }

        //The GET Method that displays the Movie Page for a logged in User
        [HttpGet]
        public ActionResult Kino(int id = 0)
        {
            Kino kinoModel = new Kino();
            return View(kinoModel);
        }

        //The POST Method that posts a new comment
        [HttpPost]
        public ActionResult Kino (Kino kinoModel)
        {
            using(KinoContext context = new KinoContext())
            {
                context.KinoComments.Add(kinoModel);
                context.SaveChanges();
            }
            return View("Kino", new Kino());
        }


        //The GET Method that displays the Music Page for a logged in User
        [HttpGet]
        public ActionResult Music(int id = 0)
        {
            Music musicModel = new Music();

            return View(musicModel);
        }

        //The POST Method that creates the new Music Model and stores them into the Database
        [HttpPost]
        public ActionResult Music(Music musicModel)
        {
            using (MusicContext context = new MusicContext())
            {
                context.MusicComments.Add(musicModel);
                context.SaveChanges();
            }
            return View("Music", new Music());
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