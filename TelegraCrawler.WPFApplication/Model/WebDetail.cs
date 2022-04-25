using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegraCrawler.WPFApplication.Model
{
    public enum DownloadStatu
    {
        GettingWebContent = 1,
        WaitForDownload = 2,
        Downloading = 4,
        Downloaded = 8,
        DownloadedHasError = 16
    }
    public class WebDetail : BaseModel
    {

        private string url;
        private string title;
        private int id;
        private int imageCount;
        private ObservableCollection<string> imagesSrc = new();
        private DownloadStatu downloadStatus;
        private string downloadDirPath;
        private List<KeyValuePair<int, string>> downloadExceptionUrls = new();

        public List<KeyValuePair<int, string>> DownloadExceptionUrls 
        {
            get => downloadExceptionUrls;
            set { downloadExceptionUrls = value; OnpropertyChanged(); }
        }

        public string DownloadDirPath
        {
            get { return downloadDirPath; }
            set { downloadDirPath = value; OnpropertyChanged(); }
        }


        public DownloadStatu DownloadStatus
        {
            get { return downloadStatus; }
            set { downloadStatus = value; OnpropertyChanged(); }
        }


        public ObservableCollection<string> ImagesSrc
        {
            get { return imagesSrc; }
            set { imagesSrc = value; OnpropertyChanged(); }
        }



        public int ImageCount
        {
            get { return imageCount; }
            set { imageCount = value; OnpropertyChanged(); }
        }

        public int Id
        {
            get { return id; }
            set { id = value; OnpropertyChanged(); }
        }


        public string Title
        {
            get { return title; }
            set { title = value; OnpropertyChanged(); }
        }


        public string Url
        {
            get { return url; }
            set { url = value; OnpropertyChanged(); }
        }

        
    }
}
