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

        private void InitCommands()
        {
            SearchCommand = new DelegateCommand(() =>
            {
                if (string.IsNullOrEmpty(UrlStr) || !IsUrl(UrlStr)) return;
                //判断是否有重复
                if (WebDetailCollection.ToList().Find(x => urlStr.ToLowerInvariant().Trim().Equals(x.Url)) is not null) return;

                var webDetail = new WebDetail() { Url = UrlStr.ToLowerInvariant().Trim(), Id = urlIndex++ };
                var td = new Thread(async () =>
                {
                    string webContent = await crawlerHelper.GetWebContent(UrlStr);
                    DeserializHtml(webContent, webDetail);
                })
                { IsBackground = true };
                td.Start();

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
            foreach (var item in WebDetailCollection)
            {
                var t = Task.Factory.StartNew(() =>
                {
                    if (item.DownloadStatus != DownloadStatu.WaitForDownload)
                    {
                        return;
                    }
                    DownloadFileHelper df = new(item);
                    item.DownloadStatus = DownloadStatu.Downloading;
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
            FindImgNode(x => x.Name.ToLowerInvariant().Equals("title"), htmlDocument, titleNodes);
            webDetail.Title = titleNodes.FirstOrDefault()?.InnerHtml ?? "";
            List<HtmlNode> imageNodes = new();
            FindImgNode(x => x.Name.ToLowerInvariant().Equals("img"), htmlDocument, imageNodes);
            webDetail.ImageCount = imageNodes.Count;
            webDetail.ImagesSrc.AddRange(imageNodes.Select(x => x.Attributes["src"].Value));
            for (int i = 0; i < webDetail.ImagesSrc.Count; i++)
            {
                if (!IsUrl(webDetail.ImagesSrc[i]))
                {
                    webDetail.ImagesSrc[i] = @"https://telegra.ph" + webDetail.ImagesSrc[i];
                }
            }

            webDetail.DownloadStatus = DownloadStatu.WaitForDownload;
        }

        private void FindImgNode(Func<HtmlNode, bool> func, HtmlNode parentNode, ICollection<HtmlNode> nodes)
        {
            foreach (var item in parentNode.ChildNodes)
            {
                FindImgNode(func, item, nodes);
                if (func.Invoke(item))
                {
                    nodes.Add(item);
                }
            }
        }


        public static bool IsUrl(string str)
        {
            try
            {
                string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
                return Regex.IsMatch(str, Url);
            }
            catch
            {
                return false;
            }
        }
    }
}
