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
		private string _buttonText = "Update";
		private string ButtonType = "update";

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
		public ICommand CreateLocationCommand
		{
			get
			{
				return new MvxCommand(CreateLocation);
			}
		}

		// When the user clicks to update their location, this function is called.
		public ICommand UpdateLocationCommand
		{
			get
			{
				return new MvxCommand(updateOrCreateLocation);
			}
		}

		public async void updateOrCreateLocation()
		{
			if (ButtonType == "update")
				UpdateLocation();
			else
				CreateLocation();
		}

        public async void UpdateLocation() {
            
			MessageResult result = await api.UpdateUserLocation(Settings.UserEmail, UserLocation);
			
            if (result != null && result.status == "success") {
                ShowViewModel<TeamPageViewModel>();
            } 
			else {
				if (result == null)
					UpdateMessage = "Server Error. Check your internet connection";
				else if (result.status == "error") {
					ButtonType = "create";
					ButtonText = "Create & Update";
					UpdateMessage = result.message + " Want to create this location ?";
				}
				toggleErrorMessage();
			}

        }

		public async void CreateLocation()
		{
			Debug.WriteLine("Creating a new location" + UserLocation);
			MessageResult result = await api.CreateLocation(new Location(0, UserLocation, ""));

			if (result != null && result.status == "success")
			{
				UpdateLocation();
			}
			else {
				if (result == null)
					UpdateMessage = "Server Error. Check your internet connection";
				toggleErrorMessage();
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

		public string ButtonText
		{
			get { return _buttonText; }
			set
			{
				if (value != null && value != _buttonText)
				{
					_buttonText = value;
					RaisePropertyChanged(() => ButtonText);
				}
			}
		}

		// Requests called on the bottom buttons
		public ICommand TeamRequestsPageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<TeamRequestsViewModel>());
			}
		}

		public ICommand TeamPageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<TeamPageViewModel>());
			}
		}

		public ICommand MyRequestsPageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<MyRequestsViewModel>());
			}
		}
	}
}
