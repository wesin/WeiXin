using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
            if (tmpStr == signature)//开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。开发者通过检验signature对请求进行校验，若确认此次GET请求来自微信服务器，请原样返回echostr参数内容，则接入生效，否则接入失败
            {
                return true;
            }
            else
                return false;
        }
    }
}
