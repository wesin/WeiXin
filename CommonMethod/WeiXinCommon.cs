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

       public const string UserInfoGet = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";

        /// <summary>
       /// 第一个拉取的OPENID，不填默认从头开始拉取
        /// </summary>
       public const string UserGet = "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}";
           
         
       /// <summary>
       /// 获取POST返回来的数据
       /// </summary>
       /// <param name="request">请求对象</param>
       /// <param name="encoding">编码格式</param>
       /// <returns></returns>
       public string PostInput(System.Web.HttpRequestBase request, Encoding encoding)
       {
           StringBuilder builder = new StringBuilder();
           try
           {
               using (System.IO.Stream s = request.InputStream)
               {
                   int count = 0;
                   byte[] buffer = new byte[1024];
                   while ((count = s.Read(buffer, 0, 1024)) > 0)
                   {
                       builder.Append(encoding.GetString(buffer, 0, count));
                   }
                   s.Flush();
                   s.Close();
                   s.Dispose();
               }
               return builder.ToString();
           }
           catch (Exception ex)
           { throw ex; }
       }
    }
}
