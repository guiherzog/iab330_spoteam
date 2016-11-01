using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Spoteam_App.Views
{
	[Activity(Label = "Team Requests")]
	public class TeamRequests: MvxActivity
	{
		protected override void OnCreate(Bundle requests)
		{
			base.OnCreate(requests);
			SetContentView(Resource.Layout.TeamRequests);
		}
	}
}
