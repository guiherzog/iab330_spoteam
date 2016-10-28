using Newtonsoft.Json;
using Spoteam.Core.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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

		public async Task<GetUserResult> Get(string table, string column, string value)
		{
			string URL = String.Format("{0}/get/{1}/{2}?value={3}", server, table, column, value);
			var uri = new Uri(URL);
			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				switch (table)
				{
					case "user":
						return JsonConvert.DeserializeObject<GetUserResult>(content);
					case "location":
					case "team":
					default:
						return null;
				}
			}
			else {
				return null;
			}
		}
	}
}
