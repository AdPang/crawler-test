using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.LoginAuth
{
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string loginName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string idCard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int offset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 用户名密码认证
        /// </summary>
        public string authMethod { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string usernameType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string enabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string accountNonExpired { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string accountNonLocked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string credentialsNonExpired { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> roleNames { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> authorityNames { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dataKey { get; set; }
    }
}
