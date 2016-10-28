using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoteam.Core.Model {
    class GetTeamResult {
        public string status { get; set; }
        public List<Team> rows { get; set; }
    }
}
