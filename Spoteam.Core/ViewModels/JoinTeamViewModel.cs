using System;
using System.Diagnostics;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Spoteam.Core.Model;
using Spoteam.Core.Models;
using Spoteam.Core.Utils;
using Spoteam.Core.ViewModels;
using Spoteam.Core.Helpers;

namespace Spoteam.Core
{
	public class JoinTeamViewModel : MvxViewModel {

		
		private string _code = "";
		private string _name = "";
		private string _email = "";

		private SpoteamAPI spoteamAPI = new SpoteamAPI();


		public ICommand JoinTeamCommand
		{
			get
			{
				return new MvxCommand(CreateUser);
			}
		}

		public async void CreateUser()
		{
			Debug.WriteLine("Team Code: " + TeamCode + " Name: " + UserEmail + " Email: " + UserName);

			User user = new User(UserEmail, UserName, "", null, Int32.Parse(TeamCode), "available");

			MessageResult result = await spoteamAPI.SetUser(user);

			Debug.WriteLine(result.message);

            if (result.status == "success") {
                ShowViewModel<TeamPageViewModel>(user);
                Settings.UserName = user.name;
                Settings.UserEmail = user.email;
                Settings.TeamId = user.teamId;
            }
            else
                Debug.WriteLine("Error: Check your account and team id.");

        }

		public string TeamCode
		{
			get { return _code; }
			set
			{
				if (value != null && value != _code)
				{
					_code = value;
					RaisePropertyChanged(() => TeamCode);
				}
			}
		}

		public string UserEmail
		{
			get { return _email; }
			set
			{
				if (value != null && value != _email)
				{
					_email = value;
					RaisePropertyChanged(() => UserEmail);
				}
			}
		}

		public string UserName
		{
			get { return _name; }
			set
			{
				if (value != null && value != _name)
				{
					_name = value;
					RaisePropertyChanged(() => UserName);
				}
			}
		}

	}
}
