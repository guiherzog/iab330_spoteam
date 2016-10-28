using System;
using System.Windows.Input;
using Spoteam.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using System.Diagnostics;

namespace Spoteam.Core
{
	public class UpdateViewModel : MvxViewModel
	{
		private string _location = "S515";
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

		// When the user clicks to update their location, this functions is called.
		public ICommand UpdateLocationCommand
		{
			get
			{
				Debug.WriteLine("Clicked on Update Location");
				return new MvxCommand(() => ShowViewModel<TeamPageViewModel>());
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
