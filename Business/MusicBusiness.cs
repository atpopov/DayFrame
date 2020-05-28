using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MusicBusiness
    {
        private MusicContext context;


        //Makes a List with the Music comments from the Database
        public List<Music> GetAll()
        {
            using (context = new MusicContext())
            {
                return context.MusicComments.ToList();
            }
        }
    }
}
