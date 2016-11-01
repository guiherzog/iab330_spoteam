using System;
using System.Windows.Input;
using Spoteam.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using System.Diagnostics;
using Spoteam.Core.Utils;
using Spoteam.Core.Model;
using Spoteam.Core.Helpers;

namespace Spoteam.Core
{
	public class UpdateViewModel : MvxViewModel
	{
		private string _location = "Room Name";
        private SpoteamAPI api = new SpoteamAPI();

		public string UserLocation
		{
			get { return _location; }
			set
			{
				if (value != null && value != _location)
				{
					_location = value;
					RaisePropertyChanged(() => UserLocation);
				}
			}
		}

		// When the user clicks to update their location, this function is called.
		public ICommand UpdateLocationCommand
		{
			get
			{
				return new MvxCommand(UpdateLocation);
			}
		}

        public async void UpdateLocation() {
            MessageResult result = await api.UpdateUserLocation(Settings.UserEmail, UserLocation);

            if (result != null && result.status == "success") {
                ShowViewModel<TeamPageViewModel>();
            } 
			else {

				if (result == null)
					UpdateMessage = "Server Error. Check your internet connection";
				else
					UpdateMessage = result.message;
				toggleErrorMessage();
				Debug.WriteLine("Error: Check your account and team id.");
			}

        }


		// Show error messages when trying to update location;
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


		private string _updateMessage;
		public string UpdateMessage
		{
			get { return _updateMessage; }
			set
			{
				if (value != null && value != _updateMessage)
				{
					_updateMessage = value;
					RaisePropertyChanged(() => UpdateMessage);
				}
			}
		}

		// Requests called on the bottom buttons
		public ICommand RequestsPageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<RequestsViewModel>());
			}
		}

		public ICommand TeamPageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<TeamPageViewModel>());
			}
		}

		public ICommand UpdatePageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<UpdateViewModel>());
			}
		}
	}
}
