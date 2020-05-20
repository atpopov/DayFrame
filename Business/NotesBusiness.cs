using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class NotesBusiness
    {
        private NotesContext context;
        public List<Notes> GetAll()
        {
            using (context = new NotesContext())
            {
                return context.Notes.ToList();
            }
        }
    }
}
