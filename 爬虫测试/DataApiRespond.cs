using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 爬虫测试
{
    public class RecordsItem
    {

        public static void PrintTitle()
        {
            Console.WriteLine($"大学名\t\t\t\t\t\t专业Id\t专业名\t预计招录\t报录人数");
        }

        /// <summary>
        /// 
        /// </summary>
        public long universityId { get; set; }
        /// <summary>
        /// 长江大学
        /// </summary>
        public string universityName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long majorId { get; set; }
        /// <summary>
        /// 广播电视编导
        /// </summary>
        public string majorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<RecordsItem> records { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int current { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> orders { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string optimizeCountSql { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string searchCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string countId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string maxLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string totalRow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pages { get; set; }
    }

    public class DataApiRespond
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string request_url { get; set; }
    }
}
