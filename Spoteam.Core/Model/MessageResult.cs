using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoteam.Core.Model {
    class MessageResult {


		public MessageResult(string status, string message)
		{
			this.status = status;
			this.message = message;
		}

		public string status { get; set; }
        public string message { get; set; }
    }
}
