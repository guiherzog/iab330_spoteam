using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Spoteam_App.Views
{
    [Activity(Label = "My Account")]
    public class ProfilePage : MvxActivity
    {
        protected override void OnCreate(Bundle profilepage)
        {
            base.OnCreate(profilepage);
            SetContentView(Resource.Layout.ProfileSetting);
        }
    }
}
