using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MySpectrum.Activities;
using MySpectrum.Fragments;
using MySpectrum.Model;

namespace MySpectrum.FragmentAdapters
{
    public class UserListFragmentAdapter : RecyclerView.Adapter
    {
        RecyclerView mRecyclerView;
        List<User> mUsers;
        MainActivity owner;

        public UserListFragmentAdapter(RecyclerView recyclerView, List<User> users, MainActivity owner)
        {
            mRecyclerView = recyclerView;
            mUsers = users;
            this.owner = owner;
        }

        public override int ItemCount
        {
            get { return mUsers.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            UserViewHolder userHolder = holder as UserViewHolder;

            userHolder.mName.Text = mUsers[position].FirstName + " " + mUsers[position].LastName;
            userHolder.mEmail.Text = mUsers[position].Email;
            userHolder.mPhone.Text = mUsers[position].Phone;

            userHolder.mView.Click += (sender, e) => 
            {
                var fragmentTransaction = owner.SupportFragmentManager.BeginTransaction();
                fragmentTransaction.Replace(Resource.Id.fragmentContainer, new SingleUserFragment(position), "SingleUser");
                fragmentTransaction.AddToBackStack("mainList");
                fragmentTransaction.Commit();
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.UserCellLayout, parent, false);

            return new UserViewHolder(row);
        }
    }

    public class UserViewHolder : RecyclerView.ViewHolder
    {
        public readonly View mView;
        public readonly TextView mName;
        public readonly TextView mEmail;
        public readonly TextView mPhone;

        public UserViewHolder(View view) : base(view)
        {
            mView = view;
            mName = view.FindViewById<TextView>(Resource.Id.txtName);
            mEmail = view.FindViewById<TextView>(Resource.Id.txtEmail);
            mPhone = view.FindViewById<TextView>(Resource.Id.txtPhone);
        }
    }
}
