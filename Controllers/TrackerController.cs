using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace DonoTrackerService.Controllers
{
    public class TrackerController : ApiController
    {
        public async Task<IHttpActionResult> GetTotals()
        {
            var content = await GetJson("https://donate.nami.org/frs-api/fundraising-pages/3425456");
            return Ok(content);
        }

        public async Task<IHttpActionResult> GetDonationList()
        {
            var content = await GetJson("https://donate.nami.org/frs-api/fundraising-pages/3425456/feed-item-donations");
            return Ok(content);
        }

        private async Task<object> GetJson(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            var json = new JavaScriptSerializer().DeserializeObject(content);
            return json;
        }
    }
}
