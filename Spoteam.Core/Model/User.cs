using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spoteam.Core.Models
{
    public class User
    {
        public string UserLocation { get; set; }
        public string UserName { get; set; }
        public int UserStatus { get; set; }
        public string UserIcon { get; set; }

        public User() { }
        public User(string userName, string unitLocation, string usericon)
        {
            UserName = userName;
            UserLocation = unitLocation;
            UserIcon = usericon;
            
        }

    }
}
