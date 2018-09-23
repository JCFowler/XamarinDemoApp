
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
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using Android.Support.Design.Widget;
using MySpectrum.Fragments;
using MySpectrum.Classes;

namespace MySpectrum.Activities
{
    [Activity(Label = "MainActivity", Theme = "@style/Theme.MySpectrum")]
    public class MainActivity : AppCompatActivity
    {
        public FloatingActionButton fab;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainLayout);

            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);

            SupportActionBar actionBar = SupportActionBar;

            var fragmentTransaction = SupportFragmentManager.BeginTransaction();
            fragmentTransaction.Add(Resource.Id.fragmentContainer, new UserListFragment());
            fragmentTransaction.Commit();

            fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (sender, e) =>
            {
                var fragmentTransactionFab = SupportFragmentManager.BeginTransaction();
                fragmentTransactionFab.Replace(Resource.Id.fragmentContainer, new CreateNewUserFragment());
                fragmentTransactionFab.AddToBackStack(null);
                fragmentTransactionFab.Commit();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_toolbar, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
            {
                case Resource.Id.action_logout:
                    Login.Logout();
                    StartActivity(new Intent(Application.Context, typeof(LoginActivity)));
                    this.Finish();
                    break;
                case Resource.Id.action_add:
                    var tx = SupportFragmentManager.BeginTransaction();
                    tx.Replace(Resource.Id.fragmentContainer, new CreateNewUserFragment());
                    tx.AddToBackStack(null);
                    tx.Commit();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}
