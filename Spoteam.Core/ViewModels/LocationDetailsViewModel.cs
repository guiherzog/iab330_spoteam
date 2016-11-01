using MvvmCross.Core.ViewModels;
using Spoteam.Core.Model;
using Spoteam.Core.Models;
using Spoteam.Core.Utils;
//using MvvmCrossDemo.Core.Services;
using System.Diagnostics;

namespace Spoteam.Core.ViewModels
{
	public class LocationDetailsViewModel : MvxViewModel
	{
		private User selectedUser;

		private string selectedusername;

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
		}
	}
}
