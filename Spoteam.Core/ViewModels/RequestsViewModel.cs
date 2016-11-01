using System;
using System.Diagnostics;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using Spoteam.Core.ViewModels;
using System.Collections.ObjectModel;
using Spoteam.Core.Model;
using Spoteam.Core.Utils;
using Spoteam.Core.Models;
using Spoteam.Core.Helpers;

namespace Spoteam.Core
{
	public class RequestsViewModel : MvxViewModel
	{
        private ObservableCollection<Request> requests;
        SpoteamAPI api = new SpoteamAPI();
        User user = new User();

        public void Init() {
            user.email = Settings.UserEmail;
            listRequests();
        }

        private async void listRequests() {
            GetRequestResult result = (GetRequestResult) await api.GetWaitingRequests(user);
            if (result != null && result.status == "success") {
                if (result.rows.Count > 0) {
                    RequestList = new ObservableCollection<Request>(result.rows);
                }
                else {
                    //No pending requests
                }
            } else {
                //Connection problem
            }
        }

        public ObservableCollection<Request> RequestList {
            get { return requests; }
            set {
                requests = value;
                RaisePropertyChanged(() => RequestList);
            }
        }

        public ICommand SelectRequestCommand {
            get {
                return new MvxCommand<Request>(selectedRequest => ShowViewModel<RequestDetailsViewModel>(selectedRequest));
            }
        }

        // Requests called on the bottom buttons
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

		public ICommand UpdatePageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<UpdateViewModel>());
			}
		}

	}
}
