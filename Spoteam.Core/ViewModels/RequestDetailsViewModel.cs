using System;
using System.Windows.Input;
using Spoteam.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using Spoteam.Core.Model;
using Spoteam.Core.Utils;

namespace Spoteam.Core {
    public class RequestDetailsViewModel : MvxViewModel {
        Request selectedRequest = new Request();
        SpoteamAPI api = new SpoteamAPI();

        public void Init(Request request) {
            selectedRequest = request;
        }
        public override void Start() {
            base.Start();
            RequesterUser = selectedRequest.requesterUser;
        }

        private string _requesterUser;
        public string RequesterUser {
            get { return _requesterUser; }
            set {
                _requesterUser = value;
                RaisePropertyChanged(() => RequesterUser);
            }
        }

        private async void finalizeRequest(string status) {
            MessageResult result = await api.UpdateRequest(selectedRequest.requesterUser, selectedRequest.requestedUser, "waiting", status);
            if (result != null && result.status == "success") {
                ShowViewModel<TeamRequestsViewModel>();
            } else {
                //Connection error
            }
        }

        public ICommand AcceptRequestCommand {
            get {
                return new MvxCommand(() => finalizeRequest("approved"));
            }
        }
        public ICommand DenyRequestCommand {
            get {
                return new MvxCommand(() => finalizeRequest("denied"));
            }
        }
    }
}
