using Data.Data;
using Data.Model;
using NUnit.Framework;
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

        [Test]
        public void Test()
        {
            List<Kino> testList = GetAll();
            List<Kino> expectedList = new List<Kino>();
            foreach (var kino in context.KinoComments)
            {
                expectedList.Add(kino);
            }
            Assert.AreEqual(expectedList, testList, "The lists should be equal.");
        }
    }
}
