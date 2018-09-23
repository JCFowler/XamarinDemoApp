using System;
using System.Collections.Generic;
using MySpectrum.Model;

namespace MySpectrum.Classes
{
    public class AppData
    {
        public static AppData instance;

        public static LoginUser curUser;

        public static int singleUserPosition;

        public static AppData GetInstance()
        {
            if (instance == null)
                instance = new AppData();

            return instance;
        }
    }
}
