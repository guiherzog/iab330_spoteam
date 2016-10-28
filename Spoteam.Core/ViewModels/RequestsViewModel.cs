using System;
using System.Diagnostics;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Spoteam.Core.ViewModels;

namespace Spoteam.Core
{
	public class RequestsViewModel : MvxViewModel
	{


		public ICommand AcceptRequestCommand
		{
			get
			{
				Debug.WriteLine("Accepted Request");
				return new MvxCommand(() => ShowViewModel<TeamPageViewModel>(new { test = "123" }));
			}
		}
		public ICommand DenyRequestCommand
		{
			get
			{
				Debug.WriteLine("Deny Request");	
				return new MvxCommand(() => ShowViewModel<TeamPageViewModel>(new { test = "123" }));
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
