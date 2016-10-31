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
            } else
                Debug.WriteLine("Error: Check your location name and connection.");

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
