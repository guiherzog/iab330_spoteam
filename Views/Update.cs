using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Spoteam_App.Views
{
	[Activity(Label = "Update Location")]
	public class Update : MvxActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Update);
		}
	}
}
