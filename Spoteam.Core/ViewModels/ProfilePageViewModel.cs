using System;
using System.Windows.Input;
using Spoteam.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace Spoteam.Core
{
	public class ProfilePageViewModel : MvxViewModel
	{
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
		public ICommand ProfilePageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<ProfilePageViewModel>());
			}
		}
	}
}
