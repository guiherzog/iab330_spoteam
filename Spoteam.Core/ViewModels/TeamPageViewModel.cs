using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Spoteam.Core.Models;
using System.Collections.Generic;
using Spoteam.Core.Model;
using Spoteam.Core.Utils;
using Spoteam.Core.Helpers;
using System.Diagnostics;

namespace Spoteam.Core.ViewModels
{
    public class TeamPageViewModel : MvxViewModel
    {
        private ObservableCollection<User> userlocations;
        SpoteamAPI api = new SpoteamAPI();
        List<User> users = new List<User>();
        User user = new User();
        private string _name = "";
        private string _img = "";

        public void Init() {
            UserName = Settings.UserName;
            user.teamId = Settings.TeamId;
            listUsers(user);
        }
        public void Init(User user) {
            UserName = user.name;
            this.user = user;
            listUsers(user);
        }
        public override void Start()
		{
			base.Start();
        }

        public async void listUsers(User user) {
            GetUserResult result = (GetUserResult) await api.Get("user", "teamId", user.teamId.ToString());
            if (result != null && result.status == "success") {
                users = result.rows;
                UserList = new ObservableCollection<User>(users);
                UserSearchList = UserList;
            }
        }

        public string UserName {
            get { return _name; }
            set {
                if (value != null && value != _name) {
                    _name = value;
                    RaisePropertyChanged(() => UserName);
                }
            }
        }

        public string UserImg {
            get { return _img; }
            set {
                if (value != null && value != _img) {
                    _img = value;
                    RaisePropertyChanged(() => UserImg);
                }
            }
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

        public ICommand SelectUserCommand {
            get {
                return new MvxCommand<User>(selectedUser => locateUser(selectedUser));
            }
        }

        public void locateUser(User user) {
            Debug.WriteLine(user.status);
            switch (user.status) {
                case "offline":
                case "busy":
                    //Toast: This user is currently user.status. Try again later.
                    break;
                case "request":
                    //Toast: Requesting user location.
                    break;
                case "available":
                    //Toast: User is currently at (SpoteamAPI.get("location", user.locationId).rows[0].name).
                    break;
                default:
                    break;
            }
        }

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
