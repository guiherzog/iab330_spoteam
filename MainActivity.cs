//
// Author: Month Yean KOH N9070095
//

using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Spoteam_App
{
    [Activity(Label = "Spoteam_App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.location_button1);

            Button tab_individual_btn = FindViewById<Button>(Resource.Id.btn_individual);
            Button tab_group_btn = FindViewById<Button>(Resource.Id.btn_individual);
            Button tab_profile_btn = FindViewById<Button>(Resource.Id.btn_profile);

            button.Click += delegate { locationrequestpage(); };
            tab_individual_btn.Click += delegate { individualpage(); };
            tab_profile_btn.Click += delegate { profilepage(); };
        }
        private void locationrequestpage()
        {
            SetContentView(Resource.Layout.LocationRequest);

            Button Buttonaccept = FindViewById<Button>(Resource.Id.btn_accept);
            Button Buttondeny = FindViewById<Button>(Resource.Id.btn_deny);
            Buttonaccept.Click += delegate { acceptedrespondpage(); };
            Buttondeny.Click += delegate { denyrespondpage(); };
        }
        private void acceptedrespondpage()
        {
            SetContentView(Resource.Layout.RequestAccepted);
        }
        private void denyrespondpage()
        {
            SetContentView(Resource.Layout.Busy);
            Button Buttontry = FindViewById<Button>(Resource.Id.btn_tryagain);
            Buttontry.Click += delegate { individualpage(); };

        }

        private void individualpage()
        {
            SetContentView(Resource.Layout.Main);
            tapbuttonevent();
            Button button = FindViewById<Button>(Resource.Id.location_button1);
            button.Click += delegate { locationrequestpage(); };
        }
        private void profilepage()
        {
            SetContentView(Resource.Layout.ProfileSetting);
            tapbuttonevent();
        }

        private void tapbuttonevent()
        {

            Button tab_individual_btn = FindViewById<Button>(Resource.Id.btn_individual);
            Button tab_group_btn = FindViewById<Button>(Resource.Id.btn_group);
            Button tab_profile_btn = FindViewById<Button>(Resource.Id.btn_profile);

            tab_individual_btn.Click += delegate { individualpage(); };
            tab_profile_btn.Click += delegate { profilepage(); };
        }
    }
}

