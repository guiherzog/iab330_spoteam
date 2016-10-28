﻿using MvvmCross.Core.ViewModels;
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
            UserName = selectedUser.name;
            UserLocation = selectedUser.location.ToString();
            UserIcon = selectedUser.image;
            GetUsers();
        }

        public async void GetUsers() {
            GetUserResult result = await spoteamAPI.Get("user", "status", "available");
            foreach (var row in result.rows) {
                Debug.WriteLine("User " + row.name + " - Email: " + row.email + " - Image: " + row.image + " - Location: " + row.location + " - Status: " + row.status);
            }
        }
    }
}
