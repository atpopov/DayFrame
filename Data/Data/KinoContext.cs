using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
   public class KinoContext : DbContext
    {
        public KinoContext()
         : base("name=KinoContext")
        {

        }
        public DbSet<Kino> KinoComments { get; set; }
    }
}
