using Data.Data;
using Data.Model;
using Microsoft.JSInterop;
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
        public List<Notes> GetAll()
        {
            using (context = new NotesContext())
            {
                return context.Notes.ToList();
            }
        }

        [JSInvokable]
        public static void SaveNote(string note)
        {
            Notes newNote = new Notes();
            newNote.Note = note;
            newNote.UserId = 1;
            using (NotesContext context = new NotesContext())
            {
                context.Notes.Add(newNote);
                context.SaveChanges();
            }

        }

    }
}
