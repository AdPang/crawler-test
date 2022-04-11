using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 爬虫测试
{

    //如果好用，请收藏地址，帮忙分享。
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

    public class Success
    {
        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string token_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string refresh_token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string scope { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string jti { get; set; }
    }


    //如果好用，请收藏地址，帮忙分享。
    public class Failed
    {
        /// <summary>
        /// 
        /// </summary>
        public string error { get; set; }
        /// <summary>
        /// 用户名或密码错误
        /// </summary>
        public string error_description { get; set; }
    }

    public class LoginApiRespond<T> where T : class
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
        public T data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string request_url { get; set; }
    }
}
