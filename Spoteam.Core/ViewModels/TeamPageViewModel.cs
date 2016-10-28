using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Spoteam.Core.Models;
using System.Diagnostics;

namespace Spoteam.Core.ViewModels
{
    public class TeamPageViewModel : MvxViewModel
    {
        private ObservableCollection<User> userlocations;

		string teamCode = "";

		public void Init(string _teamCode)
		{
			teamCode = _teamCode;
			Debug.WriteLine(teamCode);

		}
		public override void Start()
		{
			base.Start();

		}

		public TeamPageViewModel()
		{
			UserList = new ObservableCollection<User>()
			{
				new User("iris@gmail.com", "Iris", "xui", 3, "offline"),
				new User("everlyn@gmail.com", "Everlyn", "fb", 6, "busy"),
				new User("lucas@gmail.com", "Lucas", "lus", 4, "available"),
				new User("guilherme@gmail.com", "Will", "wil", 10, "available"),
			};
			UserSearchList = UserList;
			SelectUserCommand = new MvxCommand<User>(selectedLocation => ShowViewModel<SecondViewModel>(selectedLocation));

		}

        public ObservableCollection<User> UserSearchList
        {
            get { return userlocations; }
            set { SetProperty(ref userlocations, value); }

        }


        public ObservableCollection<User> UserList
        {
            get { return userlocations; }
            set { SetProperty(ref userlocations, value); }

        }

        public ICommand SelectUserCommand { get; private set; }


		// Changes to the Location page when clicked on Request location button.
        public ICommand UserLocationCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LocationRequestViewModel>());
            }
        }

		// Changes to GroupPage when clicked on Teams button.
        public ICommand GroupPageCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<GroupPageViewModel>());
            }
        }

		// Changes to TeamPage when clicked on My Team button.
        public ICommand TeamPageCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<TeamPageViewModel>());
            }
        }

		// Changes to ProfilePage when clicked on Settings button.
        public ICommand ProfilePageCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ProfilePageViewModel>());
            }
        }
    }


}
