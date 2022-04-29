using HtmlAgilityPack;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TelegraCrawler.WPFApplication.Common.Helper;
using TelegraCrawler.WPFApplication.Common.Helper.HttpHelper;
using TelegraCrawler.WPFApplication.Model;

namespace TelegraCrawler.WPFApplication.ViewModels
{
    internal class MainViewModel : BindableBase
    {

        public MainViewModel(CrawlerHelper crawlerHelper)
        {
            this.crawlerHelper = crawlerHelper;
            InitCommands();
        }
        private void ActionX(object fileName)
        {
            Console.WriteLine(fileName);
            Thread.Sleep(2000);
            Console.WriteLine(fileName);
        }
        private void InitCommands()
        {
            SearchCommand = new DelegateCommand(() =>
            {
                if (string.IsNullOrWhiteSpace(UrlStr) || string.IsNullOrEmpty(UrlStr) || !UrlStr.IsUrl()) return;
                //判断是否有重复
                if (WebDetailCollection.ToList().Find(x => urlStr.ToLowerInvariant().Trim().Equals(x.Url)) is not null) return;

                var webDetail = new WebDetail() { Url = UrlStr.ToLowerInvariant().Trim(), Id = urlIndex++ };

                Task.Factory.StartNew(async p => 
                {
                    string url = p?.ToString() ?? "";
                    string webContent = await crawlerHelper.GetWebContent(url);
                    DeserializHtml(webContent, webDetail);
                }, UrlStr);

                WebDetailCollection.Add(webDetail);

                UrlStr = "";
            });


            OpearCommand = new DelegateCommand<string>(commandParameter =>
            {
                switch (commandParameter)
                {
                    case "StartDownload":
                        StartDownloadImage();

                        break;
                    case "OpenDownloadDir":
                        break;
                    default:
                        break;
                }
            });
        }

        private void StartDownloadImage()
        {
            foreach (var webDetail in WebDetailCollection)
            {
                var t = Task.Factory.StartNew(() =>
                {
                    if (webDetail.DownloadStatus != DownloadStatu.WaitForDownload)
                    {
                        return;
                    }
                    DownloadFileHelper df = new(webDetail);
                    df.DownloadImage();
                    webDetail.DownloadStatus = DownloadStatu.Downloading;
                });

            }
        }

        #region properties
        public DelegateCommand SearchCommand { get; private set; }
        public DelegateCommand<string> OpearCommand { get; set; }

        private ObservableCollection<WebDetail> webDetailCollection = new();
        private string urlStr = "";
        private readonly CrawlerHelper crawlerHelper;
        private int urlIndex = 1;

        /// <summary>
        /// Url
        /// </summary>
        public string UrlStr
        {
            get { return urlStr; }
            set { urlStr = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Web数据集合
        /// </summary>
        public ObservableCollection<WebDetail> WebDetailCollection
        {
            get
            {
                return webDetailCollection;
            }
            set
            {
                webDetailCollection = value; RaisePropertyChanged();
            }
        }
        #endregion


        private void DeserializHtml(string webContent, WebDetail webDetail)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(webContent);
            //获取网页title
            var htmlDocument = doc.DocumentNode.ChildNodes["html"];//.EndNode.ChildNodes["html"].ChildNodes["head"].ChildNodes["title"].InnerHtml;
            List<HtmlNode> titleNodes = new();
            htmlDocument.FindImgNode(x => x.Name.ToLowerInvariant().Equals("title"), titleNodes);
            webDetail.Title = titleNodes.FirstOrDefault()?.InnerHtml ?? "";
            List<HtmlNode> imageNodes = new();
            htmlDocument.FindImgNode(x => x.Name.ToLowerInvariant().Equals("img"), imageNodes);
            webDetail.ImageCount = imageNodes.Count;
            webDetail.ImagesSrc.AddRange(imageNodes.Select(x => x.Attributes["src"].Value));
            for (int i = 0; i < webDetail.ImagesSrc.Count; i++)
            {
                if (!webDetail.ImagesSrc[i].IsUrl())
                {
                    webDetail.ImagesSrc[i] = @"https://telegra.ph" + webDetail.ImagesSrc[i];
                }
            }
            webDetail.DownloadStatus = DownloadStatu.WaitForDownload;
        }



    }
}
