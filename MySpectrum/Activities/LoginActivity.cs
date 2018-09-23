
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
    [Activity(Label = "LoginActivity", Theme = "@style/Theme.MySpectrum")]
    public class LoginActivity : AppCompatActivity
    {
        EditText mUsername;
        EditText mPass;
        CheckBox mRemember;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LoginLayout);

            mUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            mPass = FindViewById<EditText>(Resource.Id.txtPassword);
            mRemember = FindViewById<CheckBox>(Resource.Id.checkbox);
            Button loginBtn = FindViewById<Button>(Resource.Id.btnLogin);
            TextView createBtn = FindViewById<TextView>(Resource.Id.btnSignUp);

            loginBtn.Click += LoginBtn_Click;
            createBtn.Click += CreateBtn_Click;
        }

        void LoginBtn_Click(object sender, EventArgs e)
        {
            if(Login.SignIn(mUsername.Text, mPass.Text, mRemember.Checked, this))
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                this.Finish();
            }
        }

        void CreateBtn_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(SignUpActivity)));
        }
    }
}
