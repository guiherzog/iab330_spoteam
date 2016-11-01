using System;
using System.Windows.Input;
using Spoteam.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using Spoteam.Core.Model;
using Spoteam.Core.Utils;
using Spoteam.Core.Helpers;
using MvvmCross.Platform;

namespace Spoteam.Core
{
	public class ProfilePageViewModel : MvxViewModel
	{
		SpoteamAPI api = new SpoteamAPI();
		IToast toast = Mvx.Resolve<IToast>();

		private async void updateStatus()
		{
			MessageResult result = await api.UpdateUserStatus(Settings.UserEmail, SelectedItem.Value);
			if (result != null && result.status == "success")
			{
				toast.Show("Status succesfully updated.");
			}
			else {
				toast.Show("Error updating status. Check your connection.");
			}
		}

		public ICommand UpdateStatusCommand
		{
			get
			{
				return new MvxCommand(() => updateStatus());
			}
		}
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
		private List<Thing> _items = new List<Thing>()
		{
		   new Thing("Available","available"),
		   new Thing("Request Only","request"),
		   new Thing("Busy","busy"),
		   new Thing("Offline","offline"),
		};
		public List<Thing> Items
		{
			get { return _items; }
			set { _items = value; RaisePropertyChanged(() => Items); }
		}
		private Thing _selectedItem = new Thing("Available", "available");
		public Thing SelectedItem
		{
			get { return _selectedItem; }
			set { _selectedItem = value; RaisePropertyChanged(() => SelectedItem); }
		}
		private string _userName = Settings.UserName;
		public string UserName
		{
			get { return _userName; }
		}
	}
}
