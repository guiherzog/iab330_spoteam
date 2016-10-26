using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Spoteam_App.Views
{
    [Activity(Label = "My Teams")]
    public class GroupPage : MvxActivity
    {
        protected override void OnCreate(Bundle group)
        {
            base.OnCreate(group);
            SetContentView(Resource.Layout.Group);
        }
    }
}
