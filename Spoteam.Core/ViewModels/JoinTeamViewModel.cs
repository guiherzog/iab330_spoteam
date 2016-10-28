using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Spoteam.Core.ViewModels;

namespace Spoteam.Core
{
	public class JoinTeamViewModel : MvxViewModel {

		

		public ICommand JoinTeamCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<TeamPageViewModel>(new { test = "123" } ));
			}
		}

		private string _code = "1234";
		public string TeamCode
		{
			get { return _code; }
			set
			{
				if (value != null && value != _code)
				{
					_code = value;
					RaisePropertyChanged(() => TeamCode);
				}
			}
		}

	}
}
