using MvvmCross.Core.ViewModels;
using Spoteam.Core.Model;
using Spoteam.Core.Models;
using Spoteam.Core.Utils;
//using MvvmCrossDemo.Core.Services;
using System.Diagnostics;

namespace Spoteam.Core.ViewModels
{
	public class SecondViewModel : MvxViewModel
	{
		private User selectedUser;

		private string selectedusername;

		private SpoteamAPI spoteamAPI = new SpoteamAPI();


		public string UserName
		{
			get { return selectedusername; }
			set { SetProperty(ref selectedusername, value); }
		}

		private string selecteduserlocation;

		public string UserLocation
		{
			get { return selecteduserlocation; }
			set { SetProperty(ref selecteduserlocation, value); }
		}
		private string selectedusericon;

		public string UserIcon
		{
			get { return selectedusericon; }
			set { SetProperty(ref selectedusericon, value); }
		}

		public void Init(User parameters)
		{
			selectedUser = parameters;
		}
		public override void Start()
		{
			base.Start();
			UserName = selectedUser.name;
			UserLocation = selectedUser.locationId.ToString();
			UserIcon = selectedUser.img;
			GetUsers();
		}

		public async void GetUsers()
		{
			GetUserResult result = (GetUserResult) await spoteamAPI.Get("user");
			foreach (var row in result.rows)
			{
				Debug.WriteLine("User " + row.name + " - Email: " + row.email + " - Image: " + row.img + " - Location: " + row.locationId + " - Team: " + row.teamId + " - Status: " + row.status);
			}
            GetTeamResult teamResult = (GetTeamResult) await spoteamAPI.Get("team");
            foreach (var row in teamResult.rows) {
                Debug.WriteLine("Team " + row.name + " - Id: " + row.id + " - Img: " + row.img);
            }
            GetRequestResult requestResult = (GetRequestResult) await spoteamAPI.Get("request");
            foreach (var row in requestResult.rows) {
                Debug.WriteLine("User " + row.requesterUser + " requested user " + row.requestedUser + ". Status: " + row.status);
            }
        }
	}
}
