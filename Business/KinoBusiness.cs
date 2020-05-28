using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class KinoBusiness
    {
        private KinoContext context;


        //Makes a List with the Kino comments from the Database
        public List<Kino> GetAll()
        {
            using (context = new KinoContext())
            {
                return context.KinoComments.ToList();
            }
        }
    }
}
