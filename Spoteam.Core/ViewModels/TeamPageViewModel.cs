using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Spoteam.Core.Models;
using System.Diagnostics;
using System.Collections.Generic;
using Spoteam.Core.Model;
using Spoteam.Core.Utils;

namespace Spoteam.Core.ViewModels
{
    public class TeamPageViewModel : MvxViewModel
    {
        private ObservableCollection<User> userlocations;
        SpoteamAPI api = new SpoteamAPI();
        List<User> users = new List<User>();

        public void Init(User user) {
            listUsers(user);
        }
        public override void Start()
		{
			base.Start();

        }

        public async void listUsers(User user) {
            GetUserResult result = (GetUserResult) await api.Get("user", "teamId", user.teamId.ToString());
            if (result.status == "success") {
                users = result.rows;
                UserList = new ObservableCollection<User>(users);
                UserSearchList = UserList;
            }
        }

		public TeamPageViewModel()
		{
			SelectUserCommand = new MvxCommand<User>(selectedLocation => ShowViewModel<SecondViewModel>(selectedLocation));

		}

        public ObservableCollection<User> UserSearchList
        {
            get { return userlocations; }
            set {
                userlocations = value;
                RaisePropertyChanged(() => UserSearchList);
            }
        }


        public ObservableCollection<User> UserList
        {
            get { return userlocations; }
            set {
                userlocations = value;
                RaisePropertyChanged(() => UserList);
            }
        }

        public ICommand SelectUserCommand { get; private set; }


        public ICommand RequestsPageCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<RequestsViewModel>());
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

		// Changes to ProfilePage when clicked on Settings button.
		public ICommand UpdatePageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<UpdateViewModel>());
			}
		}
    }


}
