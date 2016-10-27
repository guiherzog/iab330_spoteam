using MvvmCross.Core.ViewModels;
using Spoteam.Core.Model;
using Spoteam.Core.Models;
using Spoteam.Core.Utils;
//using MvvmCrossDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoteam.Core.ViewModels
{
    public class SecondViewModel : MvxViewModel
    {
        private User selectedUser;

        private string selectedusername;

        private SpoteamAPI spoteamAPI = new SpoteamAPI();
        

        public string UserName
        {
            get { return selectedusername; }
            set { SetProperty(ref selectedusername, value); }
        }

        private string selecteduserlocation;

        public string UserLocation
        {
            get { return selecteduserlocation; }
            set { SetProperty(ref selecteduserlocation, value); }
        }
        private string selectedusericon;

        public string UserIcon
        {
            get { return selectedusericon; }
            set { SetProperty(ref selectedusericon, value); }
        }

        public void Init(User parameters)
        {
            selectedUser = parameters;
        }
        public override void Start()
        {
            base.Start();
            UserName = selectedUser.UserName;
            UserLocation = selectedUser.UserLocation;
            UserIcon = selectedUser.UserIcon;
            GetUsers();
        }

        public async void GetUsers() {
            SelectResult result = await spoteamAPI.RefreshDataAsync();
            Debug.WriteLine("Result.status = " + result.status);
            //foreach (var item in items) {
            //    Debug.WriteLine(item.ToString());
            //}
        }
    }
}
