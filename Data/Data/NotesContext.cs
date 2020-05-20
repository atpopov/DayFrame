using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class NotesContext : DbContext
    {
        public NotesContext()
           : base("name=NotesContext")
        {

        }
        public DbSet<Notes> Notes { get; set; }
    }
}
