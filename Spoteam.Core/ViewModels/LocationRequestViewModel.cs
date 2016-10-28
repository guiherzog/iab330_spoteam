using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace Spoteam.Core
{
	public class LocationRequestViewModel : MvxViewModel
	{
		public ICommand UserAcceptCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<LocationAcceptedViewModel>());
			}
		}

		public ICommand UserDenyCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<LocationDeniedViewModel>());
			}
		}
	}
}
