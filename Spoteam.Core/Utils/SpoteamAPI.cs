using Newtonsoft.Json;
using Spoteam.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Spoteam.Core.Utils {
    class SpoteamAPI{
        HttpClient client;

        public SpoteamAPI() {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<SelectResult> RefreshDataAsync() {
            var uri = new Uri("http://13.70.86.190:8128/get/user/status?value=available");
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SelectResult>(content);
            } else {
                return null;
            }
        }
    }
}
