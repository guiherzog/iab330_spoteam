using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Spoteam_App.Views
{
    [Activity(Label = "Join Team")]
    public class JoinPage : MvxActivity
    {
        protected override void OnCreate(Bundle join)
        {
            base.OnCreate(join);
            SetContentView(Resource.Layout.Join);
        }
    }
}
