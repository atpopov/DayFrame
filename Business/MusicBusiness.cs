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

        [Test]
        public void Test()
        {
            List<Music> testList = GetAll();
            List<Music> expectedList = new List<Music>();
            foreach (var music in context.MusicComments)
            {
                expectedList.Add(music);
            }
            Assert.AreEqual(expectedList, testList, "The lists should be equal.");
        }
    }
}
