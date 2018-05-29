using Android.App;
using Android.Widget;
using Android.OS;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Fragment = Android.Support.V4.App.Fragment;
using Android.Content;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using YarshatechHamBurgerSample.Views.Home;
using YarshatechHamBurgerSample.Utils;
using System;

using YarshatechHamBurgerSample;
using Android.Support.Design.Widget;
using YarshatechHamBurgerSample.Views;

namespace YarshatechHamBurgerSample
{
    [Activity(Theme = "@style/ActionBarTheme", Label = "My App", MainLauncher = true, ConfigurationChanges = Android.Content.PM.ConfigChanges.KeyboardHidden | Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : AppCompatActivity
    {
        protected const string TAG = "MainActivity";
        CustomFragmentManager customFragment;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.home_navigation);
            // set toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetToolbar(toolbar);

            // set drawer 
            var drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            SetDrawerLayout(drawerLayout, toolbar);

           
            // Attach item selected handler to navigation view
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            // add view on main screen
            Fragment homeFragment = new HomeFragment();
            customFragment = new CustomFragmentManager();
            customFragment.AddFragment(this, homeFragment,"HomeFragment");



        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch(e.MenuItem.ItemId)
            {
                case Resource.Id.nav_home:
                    customFragment.ReplaceFragment(this, new HomeFragment());
                    break;
                case Resource.Id.nav_item1:
                    customFragment.ReplaceFragment(this, new NavItemOneFragment());
                    break;
                case Resource.Id.nav_item2:
                    customFragment.ReplaceFragment(this, new NavItemTwoFragment());
                    break;
            }
        }

        protected void SetToolbar(Toolbar toolbar)
        {
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.app_name);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        protected void SetDrawerLayout(DrawerLayout drawerLayout, Toolbar toolbar)
        {
            // Create ActionBarDrawerToggle button and add it to the toolbar
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
        }

       

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return base.OnCreateOptionsMenu(menu);
        }
    }
}

