using System;
using System.Windows.Input;
using Spoteam.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace Spoteam.Core
{
	public class ProfilePageViewModel : MvxViewModel
	{
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
