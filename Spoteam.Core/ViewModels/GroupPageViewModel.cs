using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Spoteam.Core.ViewModels;

namespace Spoteam.Core
{
	public class GroupPageViewModel : MvxViewModel
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
