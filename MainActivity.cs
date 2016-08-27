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
            //Button Buttonaccept = FindViewById<Button>(Resource.Id.btn_accept);
            //Button Buttondeny = FindViewById<Button>(Resource.Id.btn_deny);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            button.Click += delegate { locationrequestpage(); };
            //Buttonaccept.Click += delegate { SetContentView(Resource.Layout.RequestAccepted); };
            //Buttondeny.Click += delegate { SetContentView(Resource.Layout.Main); };
        }
        private void locationrequestpage()
        {
            SetContentView(Resource.Layout.LocationRequest);

            Button Buttonaccept = FindViewById<Button>(Resource.Id.btn_accept);
            Button Buttondeny = FindViewById<Button>(Resource.Id.btn_deny);
            Buttonaccept.Click += delegate { locationacceptedrespond(); };
            Buttondeny.Click += delegate { locationdenyedrespond(); };
        }
        private void locationacceptedrespond()
        {
            SetContentView(Resource.Layout.RequestAccepted);
        }
        private void locationdenyedrespond()
        {
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.location_button1);
            button.Click += delegate { locationrequestpage(); };
        }
    }
}

