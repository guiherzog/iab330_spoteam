using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Spoteam.Core.Models;
using System.Collections.Generic;
using Spoteam.Core.Model;
using Spoteam.Core.Utils;
using Spoteam.Core.Helpers;
using System.Diagnostics;
using MvvmCross.Platform;
using System;

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
			user.email = Settings.UserEmail;
            user.teamId = Settings.TeamId;
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
				Debug.WriteLine(users.Count);
                UserList = new ObservableCollection<User>(users);
                UserSearchList = UserList;

				Debug.WriteLine("User Email "+this.user.email);
				foreach (var u in UserList)
				{
					Debug.WriteLine(u);
					if (u.email == this.user.email)
					{
						this.user.status = u.status;
						this.user.locationId = u.locationId;
						UserList.Remove(u);
						UserStatus = this.user.status;
						setUserLocation();
						break;
					}
				}

            }

        }

		public async void setUserLocation()
		{
			GetLocationResult location = (GetLocationResult)await api.Get("location", "id", this.user.locationId.ToString());
			if (location != null && location.status == "success")
			{
				UserLocation = location.rows[0].name;
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

		private string _location;
		public string UserLocation
		{
			get { return _location; }
			set
			{
				if (value != null && value != _location)
				{
					_location = value;
					RaisePropertyChanged(() => UserLocation);
				}
			}
		}

		private string _status = "";
		public string UserStatus
		{
			get { return _status; }
			set
			{
				if (value != null && value != _status)
				{
					_status = value;
					RaisePropertyChanged(() => UserStatus);
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

        public async void locateUser(User user) {
            Debug.WriteLine(user.status);
            var toast = Mvx.Resolve<IToast>();
            switch (user.status) {
                case "offline":
                case "busy":
                    toast.Show("This user is currently " + user.status + ". Try again later.");
                    //Toast: This user is currently user.status. Try again later.
                    break;
                case "request":
					toast.Show("Requesting user location.");
					DateTime now = DateTime.Now;
					Request request = new Request(Settings.UserEmail, user.email, now, "waiting");
                    MessageResult result = await api.CreateRequest(request);
                    if (result != null && result.status == "success") {
						toast.Show("Location of " + user.name + " requested.");
                        //Toast: Requesting user location.
                    } else {
                        toast.Show("Error requesting user location.");
                        //Toast: Error requesting user location.
                    }
					
                    break;
                case "available":
                    if (user.locationId != null) {
                        Debug.WriteLine("start api.get.location");
                        GetLocationResult locationResult = (GetLocationResult) await api.Get("location", "id", user.locationId.ToString());
                        Debug.WriteLine("end api.get.location");
                        if (locationResult != null && locationResult.status == "success")
                            toast.Show("User is currently at " + locationResult.rows[0].name + ".");
                        else
                            toast.Show("Request Error: Check your connection and try again.");
                    } else {
                        toast.Show("Location unavailable for this user.");
                    }
                    //Toast: User is currently at (SpoteamAPI.get("location", user.locationId).rows[0].name).
                    break;
                default:
                    break;
            }
        }

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

        public ICommand ProfilePageCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ProfilePageViewModel>());
            }
        }

		public ICommand UpdatePageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<UpdateViewModel>());
			}
		}

		// Switch to MyRequestsPage
		public ICommand MyRequestsPageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<MyRequestsViewModel>());
			}
		}
    }


}
