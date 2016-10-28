using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoteam.Core.Model {
    class GetLocationResult {
        public string status { get; set; }
        public List<Location> rows { get; set; }
    }
}
