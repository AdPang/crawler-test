using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.UniversityDetail
{
    public class UniversityData
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
}
