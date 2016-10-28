using Spoteam.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoteam.Core.Model {
    class GetUserResult {
        public string status { get; set; }
        public List<User> rows { get; set; }
    }
}
