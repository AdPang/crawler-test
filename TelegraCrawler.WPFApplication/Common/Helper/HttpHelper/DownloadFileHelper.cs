using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TelegraCrawler.WPFApplication.Model;

namespace TelegraCrawler.WPFApplication.Common.Helper.HttpHelper
{
    public class DownloadFileHelper
    {
        private readonly string imageSaveDir;
        private readonly WebDetail webDetail;
        List<KeyValuePair<int, string>> ImageFiles = new();

        public DownloadFileHelper(WebDetail webDetail,List<KeyValuePair<int, string>> globalExceptionUrl)
        {
            this.webDetail = webDetail;
            string downloadDirPath = GetDirPath(webDetail.Title);
            webDetail.DownloadDirPath = downloadDirPath;
            for (int imageIndex = 0; imageIndex < webDetail.ImagesSrc.Count; imageIndex++)
                ImageFiles.Add(new KeyValuePair<int, string>(imageIndex + 1, webDetail.ImagesSrc[imageIndex]));

            DownloadImage();
        }

        private string GetDirPath(string title)
        {
            string path = @$"D:\Data\ImageSave\{title}";
            if (!Directory.Exists(path)) 
            {
                Directory.CreateDirectory(path);
                return path;
            }
            //string path = @$"D:\Data\ImageSave\{title}{(index > 0 ? index.ToString() : "")}";

            for (int i = 1; i < int.MaxValue; i++)
            {
                path = @$"D:\Data\ImageSave\{title}{i}";
                if (!Directory.Exists(path))
                {
                    break;
                }
            }
            Directory.CreateDirectory(path);
            return path;
        }

        private List<List<KeyValuePair<int, string>>> SpiltPair(int n = 10)
        {
            List<List<KeyValuePair<int, string>>> listDir = new();
            for (int i = 0; i < ImageFiles.Count/n; i++)
                listDir.Add(ImageFiles.Skip(i * n).Take(n).ToList());
            listDir.Add(ImageFiles.Skip(ImageFiles.Count / n * n).Take(ImageFiles.Count % n).ToList());
            return listDir;
        }

        public void DownloadImage()
        {
            var collection = SpiltPair();
            List<Thread> threads = new(); 
            int completeCount = 0;
            foreach (var listItem in collection)
            {
                
                var td = new Thread(async () =>
                {
                    using (var web = new WebClient())
                    {
                        foreach (var item in listItem)
                        {
                            this.webDetail.DownloadStatus = DownloadStatu.Downloading;
                            try
                            {
                                await web.DownloadFileTaskAsync(item.Value, @$"{webDetail.DownloadDirPath}\{item.Key}.jpg");
                            }
                            catch (Exception)
                            {
                                this.webDetail.DownloadExceptionUrls.Add(item);
                            }
                        }
                    }
                    completeCount++;

                    if (completeCount == collection.Count)
                    {
                        this.webDetail.DownloadStatus = DownloadStatu.Downloaded;
                    }
                }){ IsBackground = true };
                threads.Add(td);
            }


            this.webDetail.DownloadStatus = DownloadStatu.Downloading;
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Start();
            }

            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Join();
            }
            

        }
    }
}
