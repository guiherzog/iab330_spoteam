using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoteam.Core.Model {
    class SelectResult {
        public string status { get; set; }
        public List<Row> rows { get; set; }
    }
    public class Row {
        public string email { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int location { get; set; }
        public string status { get; set; }
    }
}
