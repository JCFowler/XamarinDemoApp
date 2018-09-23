
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MySpectrum.Activities;
using MySpectrum.Classes;
using MySpectrum.Model;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace MySpectrum.Fragments
{
    public class CreateNewUserFragment : SupportFragment
    {
        EditText first;
        EditText last;
        EditText email;
        EditText phone;
        Button btnCreate;

        User editUser;
        int userPosition;

        public CreateNewUserFragment()
        {
            editUser = null;
            userPosition = -1;
        }

        public CreateNewUserFragment(int position)
        {
            userPosition = position;
            editUser = AppData.curUser.Users[position];
        }

        public override void OnResume()
        {
            base.OnResume();

            var main = (MainActivity)Activity;
            if (editUser != null)
                main.Title = "Edit user";
            else
                main.Title = "Create new user";
            main.fab.Hide();
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.CreateNewUserLayout, container, false);

            first = view.FindViewById<EditText>(Resource.Id.txtFirst);
            last = view.FindViewById<EditText>(Resource.Id.txtLast);
            email = view.FindViewById<EditText>(Resource.Id.txtEmail);
            phone = view.FindViewById<EditText>(Resource.Id.txtPhone);
            btnCreate = view.FindViewById<Button>(Resource.Id.btnCreate);

            if (editUser != null)
            {
                first.Text = editUser.FirstName;
                last.Text = editUser.LastName;
                email.Text = editUser.Email;
                phone.Text = editUser.Phone;
                btnCreate.Text = "Save";
                btnCreate.Click += EditClick;
            }
            else
                btnCreate.Click += CreateClick;

            return view;
        }

        private void EditClick(object sender, EventArgs e)
        {
            AppData.curUser.Users[userPosition].FirstName = first.Text;
            AppData.curUser.Users[userPosition].LastName = last.Text;
            AppData.curUser.Users[userPosition].Email = email.Text;
            AppData.curUser.Users[userPosition].Phone = phone.Text;

            SaveController.SetUser(AppData.curUser);

            var main = (MainActivity)Activity;

            Toast.MakeText(main, "User updated successfully!", ToastLength.Short).Show();

            main.SupportFragmentManager.PopBackStack();
        }

        void CreateClick(object sender, EventArgs e)
        {
            User user = new User
            {
                FirstName = first.Text,
                LastName = last.Text,
                Email = email.Text,
                Phone = phone.Text
            };

            AppData.curUser.Users.Add(user);
            SaveController.SetUser(AppData.curUser);

            var main = (MainActivity)Activity;

            Toast.MakeText(main, "User created successfully!", ToastLength.Short).Show();
            
            main.SupportFragmentManager.PopBackStack();
        }
    }
}
