
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using MySpectrum.Classes;

namespace MySpectrum.Activities
{
    [Activity(Label = "SplashActivity", MainLauncher = true, Theme = "@style/MyTheme.Splash", NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SaveController.GetAutoSignIn();
            if(AppData.curUser != null)
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            else
                StartActivity(new Intent(Application.Context, typeof(LoginActivity)));
        }
    }
}
