
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
                Toast.MakeText(this, "Please fill out all fields.", ToastLength.Short).Show();
            else if (mPass1.Text != mPass2.Text)
                Toast.MakeText(this, "Passwords are not the same.", ToastLength.Short).Show();
            else if (mPass1.Text.Length <= 5 && mPass1.Text.Length >= 12)
                Toast.MakeText(this, "Password needs to be between 5 and 12 characters.", ToastLength.Short).Show();
            else if (mPass1.Text.Any(ch => !Char.IsLetterOrDigit(ch)))
                Toast.MakeText(this, "Password can only be letters and numbers.", ToastLength.Short).Show();
            else if(mPass1.Text.All(ch => !Char.IsDigit(ch)) || mPass1.Text.All(ch => !Char.IsLetter(ch)))
                Toast.MakeText(this, "Password needs both letters and numbers.", ToastLength.Short).Show();
            else if(checkSequence(mPass1.Text))
                Toast.MakeText(this, "Password cannot have any sequence of characters immediately followed by the same sequence.", ToastLength.Long).Show();
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

        bool checkSequence(string pass)
        {
            for (int i = 1; i < pass.Length;i++)
            {
                Console.WriteLine(pass.Substring(0, i));
                //Console.WriteLine(pass.Substring(i, i));
                if(i+i < pass.Length )
                    if (pass.Substring(0, i).Equals(pass.Substring(i, i)))
                        return true;
            }
            return false;
        }

    }
}
