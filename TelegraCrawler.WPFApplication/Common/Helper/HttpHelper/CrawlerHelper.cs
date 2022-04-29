using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegraCrawler.WPFApplication.Common.Helper.HttpHelper
{
    public class CrawlerHelper
    {
        public async Task<string> GetWebContent(string url)
        {
            var client = new RestClient(url)
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
