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
using Fragment = Android.Support.V4.App.Fragment;

namespace YarshatechHamBurgerSample.Views.Home
{
    public class HomeFragment : Fragment
    {
        TextView textView;
        View rootView;
        LinearLayout linearLayout;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            textView = new TextView(this.Context);
            //var layoutParams=new LinearLayout.LayoutParams(WindowManagerLayoutParams.WrapContent,WindowManagerLayoutParams.MatchParent);
            textView.LayoutParameters = new LinearLayout.LayoutParams(WindowManagerLayoutParams.WrapContent, WindowManagerLayoutParams.MatchParent);
            textView.Gravity = (GravityFlags.Center);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            // return base.OnCreateView(inflater, container, savedInstanceState);
            rootView = inflater.Inflate(Resource.Layout.home_dashboard, container, false);
            linearLayout = rootView.FindViewById<LinearLayout>(Resource.Id.linear_layout);
            linearLayout.SetBackgroundColor(Android.Graphics.Color.DarkMagenta);
            textView.Text = "I am in Home";

            linearLayout.AddView(textView);

            return rootView;
            
        }
    }
}