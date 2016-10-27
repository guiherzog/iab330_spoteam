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
        public string image { get; set; }
        public int location { get; set; }
        public string status { get; set; }

        public User() { }
        public User(string email, string name, string image, int location, string status) {
            this.email = email;
            this.name = name;
            this.image = image;
            this.location = location;
            this.status = status;
        }
    }
}
