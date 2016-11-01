using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spoteam.Core.Models
{
    public class User
    {
        public string email { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public int? locationId { get; set; }
        public int? teamId { get; set; }
        public string status { get; set; }
		public string password { get; set; }

        public User() { }
        public User(string email, string name, string password, string img, int? locationId, int? teamId, string status) {
            this.email = email;
            this.name = name;
			this.password = password;
            this.img = img;
            this.locationId = locationId;
            this.teamId = teamId;
            this.status = status;
        }
    }
}
