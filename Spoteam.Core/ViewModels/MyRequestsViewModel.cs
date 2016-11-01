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
using MvvmCross.Platform;

namespace Spoteam.Core
{
	public class MyRequestsViewModel : MvxViewModel
	{
		private ObservableCollection<Request> requests;
		SpoteamAPI api = new SpoteamAPI();
		User user = new User();

		public void Init()
		{
			user.email = Settings.UserEmail;
			listRequests();
		}

		private async void listRequests()
		{
			GetRequestResult result = (GetRequestResult)await api.GetMyRequests(user);
			if (result != null && result.status == "success")
			{
				if (result.rows.Count > 0)
				{
					RequestList = new ObservableCollection<Request>(result.rows);
				}
				else {
					//No pending requests
				}
			}
			else {
				//Connection problem
			}
		}

		public ObservableCollection<Request> RequestList
		{
			get { return requests; }
			set
			{
				requests = value;
				RaisePropertyChanged(() => RequestList);
			}
		}

		public ICommand SelectRequestCommand
		{
			get
			{
				return new MvxCommand<Request>(selectedRequest => resultRequest(selectedRequest));
			}
		}

		public async void resultRequest(Request request)
		{
			var toast = Mvx.Resolve<IToast>();
			switch (request.status)
			{
				case "denied":
					toast.Show("Finalizing request...");
					MessageResult deniedResult = await api.UpdateRequest(request.requesterUser, request.requestedUser, request.status, "done");
					if (deniedResult != null && deniedResult.status == "success")
						toast.Show("Request finalized.");
					else
						toast.Show("Error when finalizing request. Check your connection.");
					break;
				case "approved":
					GetUserResult userResult = (GetUserResult) await api.Get("user", "email", request.requestedUser);
					if (userResult != null && userResult.status == "success")
					{
						toast.Show("Obtaining user " + userResult.rows[0].name + " location...");
						if (userResult.rows[0].locationId != null)
						{
							GetLocationResult locationResult = (GetLocationResult) await api.Get("location", "id", userResult.rows[0].locationId.ToString());
							if (locationResult != null && locationResult.status == "success")
							{
								toast.Show("User " + userResult.rows[0].name + " is currently at " + locationResult.rows[0].name);
								MessageResult approvedResult = await api.UpdateRequest(request.requesterUser, request.requestedUser, request.status, "done");
								if (approvedResult != null && approvedResult.status == "success")
									toast.Show("Request finalized.");
								else
									toast.Show("Error when finalizing request. Check your connection.");
							}
							else
								toast.Show("Error when obtaining location. Check your connection.");
						}
						else
							toast.Show("User " + userResult.rows[0].name + " has not a current location.");
					}
					else
						toast.Show("Error when obtaining location. Check your connection.");
					break;
				default:
					break;	
			}
		}

		// Requests called on the bottom buttons
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

		public ICommand MyRequestsPageCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<MyRequestsViewModel>());
			}
		}

	}
}
	