using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Handlers;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace 爬虫测试
{
    public class FileRequestService
    {
        private readonly string jwt;

        public FileRequestService(string jwt)
        {
            this.jwt = jwt;
        }

        public async Task<bool> UploadFile(string uri, FileInfo file, EventHandler<HttpProgressEventArgs> httpProgressEventHandler)
        {
            HttpClientHandler handler = new HttpClientHandler();
            ProgressMessageHandler progressMessageHandler = new ProgressMessageHandler(handler);
            progressMessageHandler.HttpSendProgress += httpProgressEventHandler;

            using (var httpClient = new HttpClient(progressMessageHandler))
            {
                var content = new MultipartFormDataContent();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + jwt);
                content.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(file.FullName)), "files", file.Name);
                var result = httpClient.PostAsync(uri, content).Result.Content.ReadAsStringAsync().Result;

                Console.WriteLine(result);
            }
            return true;
            /*****/





            /*****/
        }

    }
}
