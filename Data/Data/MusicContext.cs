using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
   public class MusicContext : DbContext
    {
        public MusicContext()
         : base("name=MusicContext")
        {

        }
        public DbSet<Music> MusicComments { get; set; }
    }
}
