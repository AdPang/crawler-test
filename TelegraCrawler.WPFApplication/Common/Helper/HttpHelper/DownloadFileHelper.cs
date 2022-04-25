using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TelegraCrawler.WPFApplication.Model;

namespace TelegraCrawler.WPFApplication.Common.Helper.HttpHelper
{
    public class DownloadFileHelper
    {
        /// <summary>
        /// 声明一个锁
        /// </summary>
        private readonly object _locker = new();
        /// <summary>
        /// 主要web信息
        /// </summary>
        private readonly WebDetail webDetail;
        private readonly List<KeyValuePair<int, string>> imageFiles = new();

        public DownloadFileHelper(WebDetail webDetail)
        {
            if (webDetail is null)
            {
                throw new ArgumentNullException($"the parameter {nameof(WebDetail)} instance is null!");
            }

            this.webDetail = webDetail;
            webDetail.DownloadDirPath = IOHelper.GetNewDirName(webDetail.Title);
            for (int imageIndex = 0; imageIndex < webDetail.ImagesSrc.Count; imageIndex++)
                imageFiles.Add(new KeyValuePair<int, string>(imageIndex + 1, webDetail.ImagesSrc[imageIndex]));

            DownloadImage();
        }

        
        
        private void DownloadImage()
        {

            Task.Run(() =>
            {
                //界面数据显示downloading...
                this.webDetail.DownloadStatus = DownloadStatu.Downloading;

                //将要下载的List<键值对>切成多个List<List<键值对>>
                var collection = imageFiles.SpiltPair();
                //线程Task集合
                List<Task> tasks = new();
                TaskFactory taskFactory = new();
                //实际下载数量
                var downloadFinishedCount = 0;
                //遍历所有切片后的List集合
                foreach (var listItem in collection)
                {
                    //listItem - List<键值对> 开启线程下载list中的键值对info
                    tasks.Add(taskFactory.StartNew(() =>
                    {
                        //using HttpClient 合理释放。
                        using (var web = new HttpClient())
                        {
                            //遍历当前List<键值对> 一个一个排队下载
                            foreach (var item in listItem)
                            {
                                try
                                {
                                    //请求Url下载为byte[]
                                    var downloadImgTask = web.GetByteArrayAsync(item.Value);
                                    var bytes = downloadImgTask.Result;
                                    //将byte[]写入对应文件
                                    File.WriteAllBytesAsync(@$"{webDetail.DownloadDirPath}\{item.Key}.jpg", bytes, default).Wait();
                                    lock (_locker)
                                    {
                                        //下载完成
                                        downloadFinishedCount++;
                                    }
                                }
                                catch (Exception)
                                {
                                    //发生异常，向异常集合添加下载失败的键值对
                                    lock (_locker)
                                    { 
                                        this.webDetail.DownloadExceptionUrls.Add(item);
                                    }
                                }
                            }
                        }
                    }));
                }
                //相当于线程完毕回调，等待所有下载子线程完成后执行....
                taskFactory.ContinueWhenAll(tasks.ToArray(), task =>
                {
                    //判断实际下载数量是否和应该下载数量相等
                    if (downloadFinishedCount == webDetail.ImageCount)
                        webDetail.DownloadStatus = DownloadStatu.Downloaded;
                    else
                        webDetail.DownloadStatus = DownloadStatu.DownloadedHasError;
                });
            });
        }
    }
}
