using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Spoteam_App.Views {
    [Activity(Label = "Request Details")]
    public class RequestDetails : MvxActivity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.RequestDetails);
        }
    }
}
