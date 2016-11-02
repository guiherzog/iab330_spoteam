using System;
using System.Diagnostics;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Spoteam.Core.Model;
using Spoteam.Core.Models;
using Spoteam.Core.Utils;
using Spoteam.Core.ViewModels;
using Spoteam.Core.Helpers;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Platform;

namespace Spoteam.Core
{
	public class JoinCreateTeamViewModel : MvxViewModel {

		
		private string _code = "";
		private string _name = "";

		private string _nfcID = "";
		
		private User user = new User();
		private SpoteamAPI spoteamAPI = new SpoteamAPI();

		private readonly MvxSubscriptionToken _token;

		public JoinCreateTeamViewModel(IMvxMessenger messenger)
		{
			_token = messenger.Subscribe<NFCMessage>(OnNFCMessage);
		}

		public void OnNFCMessage(NFCMessage msg)
		{
			_nfcID = msg.ID;
			JoinUserNFC();
		}

		public void Init()
		{
			this.user.email = Settings.UserEmail;
		}
		public override void Start()
		{
			base.Start();
		}

		public ICommand CreateTeamCommand
		{
			get
			{
				return new MvxCommand(CreateTeam);
			}
		}


		public ICommand JoinTeamCommand
		{
			get
			{
				return new MvxCommand(JoinUser);
			}
		}

		IToast toast = Mvx.Resolve<IToast>();


		public async void JoinUserNFC()
		{

			MessageResult result = await spoteamAPI.UpdateUserTeamNFC(user.email, _nfcID);

			Debug.WriteLine("Joining User: " + user.email + " via nfc: " + _nfcID);
			Debug.WriteLine(result.message);

			if (result != null && result.status == "success")
			{
				Settings.TeamId = Int32.Parse(result.message);
				toast.Show("Joined successfully on Team with code: " + result.message);
				ShowViewModel<TeamPageViewModel>();
			}
			else {
				if (result == null)
					JoinMessage = "Server Error. Check your internet connection";
				else
					JoinMessage = "NFC Tag not registered. Create your team now with it!";
				toggleErrorMessage();
			}

		}

		public async void JoinUser()
		{
			
			MessageResult result = await spoteamAPI.UpdateUserTeam(user.email, TeamCode);

			Debug.WriteLine("Joining User: " + user.email + " on team: " + TeamCode);

	        if (result != null && result.status == "success") {
	             ShowViewModel<TeamPageViewModel>();
	     	     Settings.TeamId = Int32.Parse(TeamCode);
	        }
			else {
				if (result == null)
					JoinMessage = "Server Error. Check your internet connection";
				else
					JoinMessage = result.message;
				toggleErrorMessage();
			             Debug.WriteLine("Error: Check your account and team id.");
			}
		}


		public async void CreateTeam()
		{
			Team team = new Team(Int32.Parse(TeamCode), TeamName, "", _nfcID);

			MessageResult result = await spoteamAPI.CreateTeam(team);

			if (result != null && result.status == "success")
			{
				JoinUser();
			}
			else {
				if (result == null)
					JoinMessage = "Server Error. Check your internet connection";
				else
					JoinMessage = result.message;
				toggleErrorMessage();
			}

		}


		private bool _boolInViewModel = false; 
	    public bool BoolInViewModel
	    {
	        get { return _boolInViewModel; }
	        set { _boolInViewModel = value; RaisePropertyChanged(() => BoolInViewModel);}
	    }

		private void toggleErrorMessage(){
			BoolInViewModel = !BoolInViewModel;
		}

		private string _joinMessage;
		public string JoinMessage
		{
			get { return _joinMessage; }
			set
			{
				if (value != null && value != _joinMessage)
				{
					_joinMessage = value;
					RaisePropertyChanged(() => JoinMessage);
				}
			}
		}

		public string TeamName
		{
			get { return _name; }
			set
			{
				if (value != null && value != _name)
				{
					_name = value;
					RaisePropertyChanged(() => TeamName);
				}
			}
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

	}
}
