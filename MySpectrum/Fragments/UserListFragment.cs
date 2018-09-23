
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using MySpectrum.Activities;
using MySpectrum.Classes;
using MySpectrum.FragmentAdapters;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;

namespace MySpectrum.Fragments
{
    public class UserListFragment : SupportFragment
    {
        RecyclerView.Adapter mAdapter;

        public override void OnResume()
        {
            base.OnResume();

            var main = (MainActivity)this.Activity;
            main.Title = "Hello, " + AppData.curUser.Username;
            main.fab.SetImageResource(Resource.Drawable.baseline_add_white_36);
            main.fab.Show();
            mAdapter.NotifyDataSetChanged();
            AppData.singleUserPosition = -1;
            main.InvalidateOptionsMenu();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            RecyclerView recyclerView = inflater.Inflate(Resource.Layout.UserListLayout, container, false) as RecyclerView;

            recyclerView.SetLayoutManager(new LinearLayoutManager(Context));
            mAdapter = new UserListFragmentAdapter(recyclerView, AppData.curUser.Users, (MainActivity)Activity);
            recyclerView.SetAdapter(mAdapter);

            return recyclerView;
        }
    }
}
