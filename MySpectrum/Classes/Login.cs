using System;
using System.Collections.Generic;
using Android.Content;
using Android.Widget;
using MySpectrum.Model;

namespace MySpectrum.Classes
{
    public class Login
    {
        public static bool SignIn(string username, string pass, bool remember, Context context)
        {
            string message = SaveController.GetUser(username, pass);

            if (message.Equals("true"))
            {
                if(remember)
                    SaveController.SetAutoSignIn();
                return true;
            }
            
            Toast.MakeText(context, message, ToastLength.Short).Show();
            return false;
        }

        public static bool Create(string username, string pass, bool createExisting)
        {
            List<User> users = new List<User>();
            if(createExisting)
            {
                User u1 = new User { FirstName = "Bill", LastName = "Gates", Email = "bill@microsoft.com", Phone = "303-555-1111" };
                User u2 = new User { FirstName = "Jeff", LastName = "Bezos", Email = "jeff@amazon.com", Phone = "606-555-2222" };
                User u3 = new User { FirstName = "Mark", LastName = "Zuckerberg", Email = "mark@facebook.com", Phone = "909-555-3333" };
                User u4 = new User { FirstName = "Steve", LastName = "Jobs", Email = "steve@apple.com", Phone = "101-555-4444" };
                User u5 = new User { FirstName = "Elon", LastName = "Musk", Email = "elon@tesla.com", Phone = "505-555-5555" };
                users.Add(u1);
                users.Add(u2);
                users.Add(u3);
                users.Add(u4);
                users.Add(u5);
            }
            LoginUser user = new LoginUser { Username = username, Password = pass, Users = users };

            return SaveController.CreateNewUser(user);
        }

        public static void Logout()
        {
            AppData.curUser = null;
            SaveController.DeleteAutoSignIn();
        }
    }
}
