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
    public class CookBusiness
    {
        private CookContext context;

        //Makes a set with the current Cook Data from the Database
        public List<Cook> GetAll()
        {
            using (context = new CookContext())
            {
                return context.CookComments.ToList();
            }
        }

        [Test]
        public void Test()
        {
            List<Cook> testList = GetAll();
            List<Cook> expectedList = new List<Cook>();
            foreach (var cook in context.CookComments)
            {
                expectedList.Add(cook);
            }
            Assert.AreEqual(expectedList, testList, "The lists should be equal.");
        }
    }
}
