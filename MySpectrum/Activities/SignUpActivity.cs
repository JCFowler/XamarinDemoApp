
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
    [Activity(Label = "SignUpActivity", Theme = "@style/Theme.MySpectrum")]
    public class SignUpActivity : AppCompatActivity
    {
        EditText mUsername;
        EditText mPass1;
        EditText mPass2;
        CheckBox mCheck;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignUpLayout);

            mUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            mPass1 = FindViewById<EditText>(Resource.Id.txtPassword1);
            mPass2 = FindViewById<EditText>(Resource.Id.txtPassword2);
            mCheck = FindViewById<CheckBox>(Resource.Id.checkbox);
            Button signUp = FindViewById<Button>(Resource.Id.btnSignUp);

            signUp.Click += SignUp_Click;
        }

        void SignUp_Click(object sender, EventArgs e)
        {
            if (mUsername.Text == "" || mPass1.Text == "" || mPass2.Text == "")
            {
                Toast.MakeText(this, "Please fill out all fields.", ToastLength.Short).Show();
            }
            else if (mPass1.Text.Length <= 6)
            {
                Toast.MakeText(this, "Password needs to be more than 6 characters.", ToastLength.Short).Show();
            }
            else if (mPass1.Text != mPass2.Text)
            {
                Toast.MakeText(this, "Passwords are not the same.", ToastLength.Short).Show();
            }
            else
            {
                bool created = Login.Create(mUsername.Text, mPass1.Text, mCheck.Checked);
                if(created)
                {
                    Toast.MakeText(this, "User was created successfully!", ToastLength.Short).Show();
                    Finish();
                }                    
                else
                    Toast.MakeText(this, "Failed to created. This username is already taken.", ToastLength.Short).Show();
            }
        }

    }
}
