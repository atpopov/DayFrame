using Data.Data;
using Data.Model;
using Microsoft.JSInterop;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class NotesBusiness
    {
        private NotesContext context;

        //Makes a List with the notes from the Database
        public List<Notes> GetAll()
        {
            using (context = new NotesContext())
            {
                return context.Notes.ToList();
            }
        }

        [Test]
        public void Test()
        {
            List<Notes> testList = GetAll();
            List<Notes> expectedList = new List<Notes>();
            foreach (var note in context.Notes)
            {
                expectedList.Add(note);
            }
            Assert.AreEqual(expectedList, testList, "The lists should be equal.");
        }

    }
}
