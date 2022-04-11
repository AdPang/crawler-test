using Models.Dtos.UniversityDetail;
using Models.Respond;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequest.APICrawler
{
    public class CrawlerHelper
    {
        private readonly string _token = "";


        public CrawlerHelper(string username = "17671655819", string password = "xztaw520.")
        {
            _token = GetToken(username, password);
            GetUniversityAndMajor();
            GetDataDetail();
        }


        public List<RecordsItem> DataList { get; private set; } = new();
        private UniversityAndMajorRespond universityAndMajorRespond = new();


        public UniversityAndMajorRespond UniversityAndMajorRespond
        {
            get { return universityAndMajorRespond; }
        }

        public List<RecordsItem> UpdataData()
        {
            GetDataDetail();
            return this.DataList;
        }

        private string GetToken(string username, string password)
        {
            try
            {
                var client = new RestClient("https://zsb.e21.cn/oauth/token");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Basic Y2xpZW50LTAxOmNsaWVudC0wMS1zZWNyZXQ=");
                request.AlwaysMultipartFormData = true;
                request.AddParameter("grant_type", "password");
                request.AddParameter("scope", "all");
                request.AddParameter("username", username);
                request.AddParameter("password", password);
                IRestResponse response = client.Execute(request);
                var result = JsonConvert.DeserializeObject<LoginApiRespond>(response.Content);
                return result.data.access_token;
            }
            catch
            {
                return "";
            }

        }
        private void GetUniversityAndMajor()
        {
            var client = new RestClient("https://zsb.e21.cn/api/v1/dic/dicVal/getDicValApply");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {_token}");

            IRestResponse response = client.Execute(request);
            universityAndMajorRespond = JsonConvert.DeserializeObject<UniversityAndMajorRespond>(response.Content);
        }

        private void GetDataDetail()
        {
            if (string.IsNullOrEmpty(_token))
                throw new Exception("token is null!");
            try
            {
                var client = new RestClient("https://zsb.e21.cn/api/v1/statistics/applyNum?total=672&_page=1&_limit=672&universityId=&majorId=&applyRate=")
                {
                    Timeout = -1
                };
                var request = new RestRequest(Method.GET);

                request.AddHeader("Authorization", $"Bearer {_token}");

                IRestResponse response = client.Execute(request);
                var httpResult = JsonConvert.DeserializeObject<DataApiRespond>(response.Content);
                //List<RecordsItem>
                var records = httpResult.data.records;//.FindAll(x => (x.majorName.Equals("物联网工程") || x.majorName.Equals("软件工程") || x.majorName.Equals("计算机科学与技术"))).ToList();

                this.DataList = records;

            }
            catch
            {
                this.DataList = new();
            }
        }


    }
}
