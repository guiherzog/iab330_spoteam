using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoteam.Core.Model {
    class GetRequestResult {
        public string status { get; set; }
        public List<Request> rows { get; set; }
    }
}
