
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
    public class SingleUserFragment : SupportFragment
    {
        User clickedUser;
        int userposition;

        public SingleUserFragment(int position)
        {
            clickedUser = AppData.curUser.Users[position];
            userposition = position;
            AppData.singleUserPosition = position;
        }

        public override void OnResume()
        {
            base.OnResume();

            var main = (MainActivity)Activity;
            main.Title = clickedUser.FirstName + " " + clickedUser.LastName;
            main.fab.SetImageResource(Resource.Drawable.baseline_delete_white_36);
            main.fab.Show();
            main.InvalidateOptionsMenu();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.SingleUserLayout, container, false);

            TextView name = view.FindViewById<TextView>(Resource.Id.txtName);
            TextView email = view.FindViewById<TextView>(Resource.Id.txtEmail);
            TextView phone = view.FindViewById<TextView>(Resource.Id.txtPhone);
            Button btnEdit = view.FindViewById<Button>(Resource.Id.btnEdit);

            name.Text = clickedUser.FirstName + " " + clickedUser.LastName;
            email.Text = clickedUser.Email;
            phone.Text = clickedUser.Phone;

            btnEdit.Click += BtnEdit_Click; 

            return view;
        }

        void BtnEdit_Click(object sender, EventArgs e)
        {
            var main = (MainActivity)Activity;
            var tx = main.SupportFragmentManager.BeginTransaction();
            tx.Replace(Resource.Id.fragmentContainer, (new CreateNewUserFragment(userposition)));
            tx.AddToBackStack(null);
            tx.Commit();
        }

    }
}
