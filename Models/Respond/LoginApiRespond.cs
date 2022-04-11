using Models.Dtos.LoginAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Respond
{
    public class LoginApiRespond
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
        public LoginData data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string request_url { get; set; }
    }
}
