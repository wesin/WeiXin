using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMethod
{
    public class WeiXinCommon
    {
       public static string APPID = "wx04a6b6cfcfdc96c6";
       public static string APPSECRET = "d13c7fc38ead559c71b7cab5dd9c7e91";

       public static string Access_token = "";

        /// <summary>
        /// 获取token的接口
        /// </summary>
       public const string AccessTokenStr = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

       public const string MenuCreate = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";

       public const string MessageSend = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";
    }
}
