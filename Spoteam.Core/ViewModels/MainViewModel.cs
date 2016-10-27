using MvvmCross.Core.ViewModels;
//using MvvmCrossDemo.Core.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Spoteam.Core.Models;

namespace Spoteam.Core.ViewModels
{
    public class TeamPageViewModel : MvxViewModel
    {
        private ObservableCollection<User> userlocations;

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

        private string searchTerm;

        public string SearchTerm
        {
            get { return searchTerm; }
            set
            {
                SetProperty(ref searchTerm, value);
                if (searchTerm.Length > 3)
                {
                    SearchUser(searchTerm);
                }
                if (searchTerm.Length == 0)
                {
                    ResetSearch();
                }
            }
        }

        public ICommand SelectUserCommand { get; private set; }
        public TeamPageViewModel()
        {
            UserList = new ObservableCollection<User>()
            {
                new User("iris@gmail.com", "Iris", "", 3, "offline"),
                new User("everlyn@gmail.com", "Everlyn", "", 6, "busy"),
                new User("lucas@gmail.com", "Lucas", "", 4, "available"),
                new User("guilherme@gmail.com", "Will", "", 10, "available"),
            };
            UserSearchList = UserList;
            SelectUserCommand = new MvxCommand<User>(selectedLocation => ShowViewModel<SecondViewModel>(selectedLocation));

        }
        public async void SearchUser(string searchTerm)
        {
            UserSearchList.Clear();
            //var userlocationResults = await weatherService.GetLocations(searchTerm);
            //var bestLocationResults = userlocationResults.Where(userlocation => userlocation.Rank > 80);
            //var userlocationResults = await weatherService.GetLocations(searchTerm);
            //var bestLocationResults = userlocationResults.Where(userlocation => userlocation.Rank > 80);

            //foreach (var item in searchTerm)
            //{
            //    foreach( var userlist in userLocationLists)
            //       if(userlist.UserName.IndexOf(item) > 0)

            //        userLocationLists.Add(userlist);

            //}
        }
        public void ResetSearch()
        {
            

            UserList.Add(new User("iris@gmail.com", "Iris", "", 3, "offline"));
            UserList.Add(new User("iris@gmail.com", "Iris", "", 3, "offline"));


            UserSearchList = UserList;
        }


        public ICommand UserLocationCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LocationRequestViewModel>());
            }
        }
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

    public class LocationRequestViewModel : MvxViewModel
    {
        public ICommand UserAcceptCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LocationAcceptViewModel>());
            }
        }

        public ICommand UserDenyCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<LocationDenyViewModel>());
            }
        }
    }
    public class LocationAcceptViewModel : MvxViewModel { }
    public class LocationDenyViewModel : MvxViewModel { }
    public class GroupPageViewModel : MvxViewModel {
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
    public class ProfilePageViewModel : MvxViewModel {
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
