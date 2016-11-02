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
	public class LoginRegisterAccountViewModel : MvxViewModel
	{
		
		private string _pw = "";
		private string _name = "";
		private string _email = "";

		private SpoteamAPI spoteamAPI = new SpoteamAPI();


		public ICommand CreateAccountCommand
		{
			get
			{
				return new MvxCommand(CreateUser);
			}
		}

		public ICommand LoginCommand
		{
			get
			{
				return new MvxCommand(LoginUser);
			}
		}

		public async void LoginUser()
		{
			User testUser = new User(UserEmail, null, UserPassword, "", null, 0, null);

			GetUserResult result = await spoteamAPI.GetUser(testUser);

			Debug.WriteLine("User: " + UserEmail + "\n " + UserPassword);

			Debug.WriteLine(result);

			if (result != null && result.status == "success")
			{
				if (result.rows.Count > 0)
				{
					User user = result.rows[0];
					Settings.UserName = user.name;
					Settings.UserEmail = user.email;
					Settings.TeamId = (int) user.teamId;

					// After loggining, change the user's status to request.
					updateStatus("request");
					ShowViewModel<TeamPageViewModel>(user);
					
				}
				else {
					LoginMessage = "Email or Password invalid.";
				}
			}
			else {
				if (result == null)
					LoginMessage = "Server Error. Check your internet connection";
				else
					LoginMessage = "Email or Password invalid";
				toggleErrorMessage();
				Debug.WriteLine("Error: Check your account and team id.");
			}
		}

		private async void updateStatus(string value)
		{
			MessageResult result = await spoteamAPI.UpdateUserStatus(Settings.UserEmail, value);
		}

		public async void CreateUser()
		{

			User user = new User(UserEmail, UserName, UserPassword, "", null, null, "available");

			MessageResult result = await spoteamAPI.CreateUser(user);

			Debug.WriteLine(result.message);

			if (result != null && result.status == "success")
			{
				ShowViewModel<JoinCreateTeamViewModel>(user);
				Settings.UserName = user.name;
				Settings.UserEmail = user.email;
			}
			else {
				if (result == null)
					LoginMessage = "Server Error. Check your internet connection";
				else
					LoginMessage = result.message;
				toggleErrorMessage();
				Debug.WriteLine("Error: Check your account and team id.");
			}
		}

		private bool _boolInViewModel = false;
		public bool BoolInViewModel
		{
			get { return _boolInViewModel; }
			set { _boolInViewModel = value; RaisePropertyChanged(() => BoolInViewModel); }
		}

		private void toggleErrorMessage()
		{
			BoolInViewModel = !BoolInViewModel;
		}

		private string _loginMessage;
		public string LoginMessage
		{
			get { return _loginMessage; }
			set
			{
				if (value != null && value != _loginMessage)
				{
					_loginMessage = value;
					RaisePropertyChanged(() => LoginMessage);
				}
			}
		}

		public string UserPassword
		{
			get { return _pw; }
			set
			{
				if (value != null && value != _pw)
				{
					_pw = value;
					RaisePropertyChanged(() => UserPassword);
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
	