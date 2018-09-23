using System;
using System.IO;
using System.Threading.Tasks;
using MySpectrum.Model;
using Newtonsoft.Json;

namespace MySpectrum.Classes
{
    public class SaveController
    {
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public static string GetUser(string username, string pass)
        {
            string fileName = username + ".json"; 
            string path = Path.Combine(folderPath, fileName);

            if(!File.Exists(path))
            {
                AppData.curUser = null;
                return "User " + username +" does not Exist";
            }

            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                LoginUser jsonUser = (LoginUser)serializer.Deserialize(file, typeof(LoginUser));

                if (pass == jsonUser.Password)
                    AppData.curUser = jsonUser;
                else
                {
                    jsonUser = null;
                    return "Password is incorrect.";
                }
            }
            return "true";
        }

        public static void SetUser(LoginUser user)
        {
            string fileName = user.Username + ".json";
            string path = Path.Combine(folderPath, fileName);

            if (File.Exists(path))
                File.Delete(path);

            string dataJson = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(path, dataJson);
        }

        public static bool CreateNewUser(LoginUser user)
        {
            string fileName = user.Username + ".json";
            string path = Path.Combine(folderPath, fileName);

            if (File.Exists(path))
                return false;

            string dataJson = JsonConvert.SerializeObject(user, Formatting.Indented);
            File.WriteAllText(path, dataJson);
            return true;
        }

        public static void GetAutoSignIn()
        {
            string fileName = "autoSignIn.json";
            string path = Path.Combine(folderPath, fileName);

            if (File.Exists(path))
            {
                string username;
                using (StreamReader file = File.OpenText(path))
                {
                    username = file.ReadLine();
                }

                string userFileName = username + ".json";
                string userPath = Path.Combine(folderPath, userFileName);
                if(File.Exists(path))
                {
                    using (StreamReader file = File.OpenText(userPath))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        LoginUser jsonUser = (LoginUser)serializer.Deserialize(file, typeof(LoginUser));

                        AppData.curUser = jsonUser;
                    }
                }
            }
        }

        public static void SetAutoSignIn()
        {
            string fileName = "autoSignIn.json";
            string path = Path.Combine(folderPath, fileName);

            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllText(path, AppData.curUser.Username);
        }

        public static void DeleteAutoSignIn()
        {
            string fileName = "autoSignIn.json";
            string path = Path.Combine(folderPath, fileName);

            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
