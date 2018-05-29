using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Fragment = Android.Support.V4.App.Fragment;

namespace YarshatechHamBurgerSample.Utils
{
   public class CustomFragmentManager
    {

        public void AddFragment(Context context, Fragment newFragment, string TAG)
        {
            Fragment myFragment = null;
            Android.Support.V4.App.FragmentManager fragmentManager = ((FragmentActivity)context).SupportFragmentManager;
            Android.Support.V4.App.FragmentTransaction ft = fragmentManager.BeginTransaction();
            myFragment = fragmentManager.FindFragmentByTag(TAG);
            if (myFragment == null)
            {
                ft.Add(Resource.Id.home_frame_layout, newFragment, TAG);
                ft.AddToBackStack(null);
                ft.Commit();
            }
            else
            {
                ft.Detach(myFragment).Attach(myFragment);
                ft.Commit();
            }

        }
        public void ReplaceFragment(Context context, Android.Support.V4.App.Fragment newFragment)
        {
            Android.Support.V4.App.FragmentManager fragmentManager = ((FragmentActivity)context).SupportFragmentManager;
            Android.Support.V4.App.FragmentTransaction ft = fragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.home_frame_layout, newFragment);
            ft.AddToBackStack(null);
            ft.Commit();
        }

        public void RemoveFragment(Context context, Fragment newFragment)
        {
            Android.Support.V4.App.FragmentManager fragmentManager = ((FragmentActivity)context).SupportFragmentManager;
            Android.Support.V4.App.FragmentTransaction ft = fragmentManager.BeginTransaction();
            ft.Remove(newFragment);
            ft.AddToBackStack(null);
            ft.Commit();

        }
        public void RemoveFragment(Context context, Fragment newFragment, string TAG)
        {
            Android.Support.V4.App.FragmentManager fragmentManager = ((FragmentActivity)context).SupportFragmentManager;
            Android.Support.V4.App.FragmentTransaction ft = fragmentManager.BeginTransaction();
            ft.Remove(newFragment);
            ft.AddToBackStack(TAG);
            ft.Commit();

        }
    }
}