using Models.Dtos.UniversityDetail;

namespace Models.Respond
{
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
        public UniversityData data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string request_url { get; set; }
    }
}
