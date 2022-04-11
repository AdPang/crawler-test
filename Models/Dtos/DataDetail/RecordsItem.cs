using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.UniversityDetail
{
    public class RecordsItem
    {

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
}
