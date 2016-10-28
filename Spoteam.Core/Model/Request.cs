namespace Spoteam.Core.Model {
    public class Request {
        public string requesterUser { get; set; }
        public string requestedUser { get; set; }
        public System.DateTime? time { get; set; }
        public string status { get; set; }

        public Request(string requesterUser, string requestedUser, System.DateTime? time, string status) {
            this.requesterUser = requesterUser;
            this.requestedUser = requestedUser;
            this.time = time;
            this.status = status;
        }
    }
}