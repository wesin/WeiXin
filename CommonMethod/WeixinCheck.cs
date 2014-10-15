using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Serialization;
using Model.JsonModel;

namespace CommonMethod
{
    public class WeixinCheck
    {
        public static readonly string Token = "fyrsyyrm";
        /// <summary>
        /// 验证微信签名
        /// </summary>
        /// <returns></returns>
        public static bool CheckSignature()
        {
            if (HttpContext.Current.Request.QueryString["signature"] == null)
            {
                return false;
            }
            string signature = HttpContext.Current.Request.QueryString["signature"].ToString();
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"].ToString();
            string nonce = HttpContext.Current.Request.QueryString["nonce"].ToString();
            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);//字典排序
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = CommonMethod.Encrypt.SHA1_Encrypt(tmpStr);
            //开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。开发者通过检验signature对请求进行校验，
            //若确认此次GET请求来自微信服务器，请原样返回echostr参数内容，则接入生效，否则接入失败
            return tmpStr == signature;
        }

        public static string GetToken()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(WeiXinCommon.AccessTokenStr, WeiXinCommon.APPID, WeiXinCommon.APPSECRET));
            request.Method = "Get";
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string tokenStr = sr.ReadToEnd();
            FileMessageSave.MessageSave(tokenStr);
            TokenModel model = JsonHelper.JsonDeserialize<TokenModel>(tokenStr);
            WeiXinCommon.Access_token = model.access_token;
            return WeiXinCommon.Access_token;
        }
    }
}
