using Newtonsoft.Json;
using Spoteam.Core.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Spoteam.Core.Models;
using System.Diagnostics;

namespace Spoteam.Core.Utils
{
	class SpoteamAPI
	{
		HttpClient client;
		private const string server = "http://13.70.86.190:8128";

		public SpoteamAPI()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}

		public async Task<MessageResult> CreateUser(User user)
		{
			string URL = String.Format("{0}/create/user?name={1}&email={2}&teamId={3}&status={4}", server, user.name, user.email, user.teamId, user.status);
			var uri = new Uri(URL);
			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<MessageResult>(content);
			}
			else {
				return null;
			}
		}

        public async Task<MessageResult> CreateRequest(Request request) {
            string URL = String.Format("{0}/create/request?requesterUser={1}&requestedUser={2}&status={3}", server, request.requesterUser, request.requestedUser, request.status);
            Debug.WriteLine(URL);
            var uri = new Uri(URL);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode) {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MessageResult>(content);
            } else {
                return null;
            }
        }

        public async Task<MessageResult> UpdateUserLocation(string userEmail, string newLocation) {
            GetLocationResult result = (GetLocationResult) await Get("location", "name", newLocation);
            if (result != null && result.status == "success" && result.rows.Count > 0) {
                string URL = String.Format("{0}/set/user/email?value={1}&locationId={2}", server, userEmail, result.rows[0].id);
                var uri = new Uri(URL);
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode) {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<MessageResult>(content);
                } else {
                    return null;
                }
            } else {
                return null;
            }
        }

        public async Task<MessageResult> UpdateRequest(string requesterUser, string requestedUser, string status) {
            string URL = String.Format("{0}/request?requester={1}&requested={2}&status={3}", server, requesterUser, requestedUser, status);
            var uri = new Uri(URL);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode) {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MessageResult>(content);
            } else {
                return null;
            }
        }

        public async Task<Object> Get(string table, string column, string value)
		{
			string URL = String.Format("{0}/get/{1}?{2}={3}", server, table, column, value);
			var uri = new Uri(URL);
			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
                switch (table) {
                    case "user":
                        return JsonConvert.DeserializeObject<GetUserResult>(content);
                    case "team":
                        return JsonConvert.DeserializeObject<GetTeamResult>(content);
                    case "request":
                        return JsonConvert.DeserializeObject<GetRequestResult>(content);
                    case "location":
                        return JsonConvert.DeserializeObject<GetLocationResult>(content);
                    default:
                        return null;
                }
            }
			else {
				return null;
			}
		}

        public async Task<GetRequestResult> GetWaitingRequests(User user) {
            string URL = String.Format("{0}/get/{1}?{2}={3}&{4}={5}", server, "request", "requestedUser", user.email, "status", "waiting");
            var uri = new Uri(URL);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode) {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GetRequestResult>(content);
            } else {
                return null;
            }
        }

        public async Task<Object> Get(string table) {
            string URL = String.Format("{0}/get/{1}", server, table);
            var uri = new Uri(URL);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode) {
                string content = await response.Content.ReadAsStringAsync();
                switch (table) {
                    case "user":
                        return JsonConvert.DeserializeObject<GetUserResult>(content);
                    case "team":
                        return JsonConvert.DeserializeObject<GetTeamResult>(content);
                    case "request":
                        return JsonConvert.DeserializeObject<GetRequestResult>(content);
                    case "location":
                        return JsonConvert.DeserializeObject<GetLocationResult>(content);
                    default:
                        return null;
                }
            } else {
                return null;
            }
        }
    }
}
