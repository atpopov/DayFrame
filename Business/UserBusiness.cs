using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        private UserContext context;

        public List<User> GetAll()
        {
            using (context = new UserContext())
            {
                return context.Users.ToList();
            }
        }

        public void Register(User user)
        {
            var AllUsers = GetAll();
            bool successfulRegister = true;

            foreach(var currentUser in AllUsers)
            {
                if(currentUser.Username == user.Username)
                {
                    successfulRegister = false;
                }
            }

            if(successfulRegister == true)
            {
                using(context = new UserContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
        }

        public void Login(User user)
        {
            var AllUsers = GetAll();
            bool successfulLogin = false;

            foreach (var currentUser in AllUsers)
            {
                if ((currentUser.Username == user.Username) && (currentUser.Password == user.Password))
                {
                    successfulLogin = true; 
                }
            }

        }
    }
}
