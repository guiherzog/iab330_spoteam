using System;
using System.Windows.Input;
using Spoteam.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace Spoteam.Core
{
	public class ProfilePageViewModel : MvxViewModel
	{
		public ICommand GroupPageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<GroupPageViewModel>());
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
